# JSON Request Payloads

This folder contains example request bodies for API testing (Postman/REST Client/curl).

## Rules

- Files **must always match the latest DTOs** in `api/Ayora.Application`.
- When a request DTO changes, update the corresponding `auth.*.json` (and any future module JSONs).

## Auth payloads

- `auth.register.json`
- `auth.login.json`
- `auth.refresh.json`
- `auth.change-password.json`
- `auth.forgot-password.json`
- `auth.reset-password.json`

