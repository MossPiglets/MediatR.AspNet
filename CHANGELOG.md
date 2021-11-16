# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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
