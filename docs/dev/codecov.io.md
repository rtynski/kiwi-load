# Konfiguracja codecov.io
## Dodawanie zmiennej do projektu
Dla projektu przechodzimy: "settings > secrets and variable > actions" :

Wybieramy "New Repository secret"
```
CODECOV_TOKEN=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxx
```
## Dodawanie akcji do workflow
```yaml
- name: Upload coverage reports to Codecov
  uses: codecov/codecov-action@v4.0.1
  with:
    token: ${{ secrets.CODECOV_TOKEN }}
    slug: rtynski/kiwi-load
```