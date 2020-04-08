.DEFAULT_GOAL 	:= default

ARTIFACTS 		:= $(shell pwd)/artifacts
BUILD			:= $(shell pwd)/.build

CONFIGURATION	:= Release

CLI_PROJECT		:= src/Resume/Resume.csproj
CLI_TOOL		:= resume
CLI_PACKAGE		:= $(CLI_TOOL)-cli

.PHONY: restore
restore:
	dotnet restore
	dotnet tool restore

default:
	$(MAKE) package

.PHONY: package
package: restore
	dotnet build -c $(CONFIGURATION) $(CLI_PROJECT)

	@echo ""
	@echo "\033[0;32mPackaging nuget \033[0m"
	@echo "\033[0;32m------------------- \033[0m"
	dotnet pack $(CLI_PROJECT) --configuration $(CONFIGURATION) \
		--no-build \
		--output $(ARTIFACTS) \
		--include-symbols
	@echo ""

.PHONY: install
install:
	dotnet tool install --global --add-source $(ARTIFACTS) \
		--version $$(dotnet minver -t v -a minor -v e) \
		$(CLI_PACKAGE)

.PHONY: uninstall
uninstall:
	dotnet tool uninstall --global $(CLI_PACKAGE)

.PHONY: update
update: uninstall install
	$(CLI_TOOL) --version
