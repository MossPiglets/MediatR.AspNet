# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 24.02.2024

### Added

- custom Exception Middleware
- possibility to create custom exceptions

### Changed

- .Net version to 6.0
- updated MediatR dependencies

### Removed

- custom Exception Filter

## [1.5.0] - 21.12.2021

### Added

- log Exceptions

## [1.4.0] - 06.12.2021

### Added

- more information in not handled exceptions

## [1.3.0] - 30.11.2021

### Added

- `ExternalServiceFailureException` 

## [1.2.0] - 30.11.2021

### Added

- interface `IQuery`
- interface `ICommand`

## [1.1.0] - 16.11.2021

### Added

- `NotAuthorizedException`

## [1.0.0] - 9.11.2021

### Added

- interface `IQuery<T>`
- interface `ICommand<T>`
- custom Exceptions:
    - `ExistsException`
    - `DeletedNotAllowedException`
    - `NotFoundException`
    - `OperationNotAllowedException`
    - `UpdateNotAllowedException`
- custom Exception Filter
