- Вступление
  - Overview докера
  - Рассказать про docker for windows
    - Так как докер сам по себе не занмается разрешениями рассказать про ReEnterCredentials
    - Рассказать, про проблему с недостатоком памяти и docker-compose
  - История интеграции докера и VS
    - Сделать recap по 2 фозможностям что у нас есть
  - План доклада
- Основная часть
  - Простое приложение
    - Сначала простое приложение без compose
    - Запустить, показать логи, объяснить, что за фикция происходит
    - Нельзя выкидывать сборки Microsoft.VisualStudio.Azure.Containers.Tools.Targets и Microsoft.AspNetCore.Razor.Design
    - Показать откуда берется порт
    - Зачем 2 Dockerfile
    - Объяснить что происходит в Dockerfile
    - Осторожно с переименованием проекта, сломается ENTRYPOINT
    - Добавляем проект, обратите внимание, что Dockerfile может быть не обновлен
    - Как ходить "назад"? Выбираем в качестве initial корневую папку
    - Не забудьте про Nuget.config
  - Приложение с docker-compose  
    - Создать docker-compose, запустить
    - Показать docker-compose в консоли
    - Разобрать его, объяснить разницу между debug и release
    - Открыть сборку в VS, отвечающую за докер и показать что там
    - Сделать docker-compose.debug/docker-compose.release
    - Показать проблему с разными именами в docker-compose и docker-compose.override
    - При переименовании проекта стоит очистить папку obj
    - Как использовать несколько dcproj файлов
  - Как это все применять
    - Недостатки
      - Производительность
      - Занятые порты
      - Pro версия windows
    - Интеграция с CI
      - Можно легко оптимизировать деплой приложений любой сложности, так как вы локально это все проверяете      
      - docker-compose push
      - Сделать отсылку на Андрея
      - Недостатки
        - Важно перед деплоем не просто запустить в visual studio, но и руками сделать docker-compose build
    - Интеграционные тесты
      - Можно протестировать все зависимости как угодно и у нас будет отладка
      - Сделать отсылку на Диму и Руслана
	  - Структура: приложение, зависимости, test runner
      - Реальный кейс:
        - Приложение
        - База данных
        - Процесс, ответсвенный за миграцию
        - Test Runner
          - Что бы работала отладка, нужно обезательно сделать консольное приложение, так как VS перетирает entirypoint
- Заключение