# WebApi ASP.NET
Это REST-приложение для бронирования залов, которое предоставляет пользователям возможность:

Бронирование залов: удобный интерфейс для создания и управления бронями конференц-залов.
Расчет цен: функционал для расчета стоимости бронирования в зависимости от выбранного зала и времени.
Добавление существующих услуг: возможность добавления и управления существующими услугами, связанными с бронью залов.
Проект использует архитектуру REST, что обеспечивает простоту взаимодействия и интеграции с другими системами.

# Документация
В проекте реализована интеграция с Swagger, что позволяет удобно просматривать и тестировать API-методы через веб-интерфейс. Swagger автоматически генерирует документацию на основе ваших контроллеров и моделей, упрощая процесс разработки и взаимодействия с API.
Вместе с проектом использовалась база данных SQL.

Чтобы установить проект на своем компьютере, выполните следующие шаги:

Скопируйте репозиторий с помощью Git:

git clone https://github.com/IShark-lab/HallBooking/
Распакуйте проект в удобное для вас место.

Измените строку подключения к базе данных в файле appsettings.json.

Создайте миграцию, выполнив команду:
Add-Migration "Имя миграции" -Project HallBooking.DLA -StartupProject HallBooking.PL
После создания миграции примените её к базе данных с помощью команды:

Update-Database

# API

# 1. Зарезервировать новый зал
HTTP метод: POST
URL: /api/Booking
Этот метод позволяет зарезервировать новый зал на основе предоставленных данных о бронировании.

Заголовки
Content-Type: application/json

Тело запроса
{
  "conferenceRoomId": {ID комнаты из бд},
  "startTime": "дата начала в формате",(2024-09-28T12:00:00)
  "endTime": "дата конца",
  "services": [{id услуги}, {id услуги}] // ID услуг, которые нужно добавить к бронированию
}


# 2. Получить все доступные залы для бронирования
HTTP метод: GET
URL: /api/Booking?strateTime={startTime}&endTime={endTime}&amountPersons={amountPersons}

Этот метод возвращает список всех доступных залов для бронирования, основываясь на входных данных.

Параметры запроса
startTime: Начало периода бронирования (формат: yyyy-MM-ddTHH:mm:ss).
endTime: Конец периода бронирования (формат: yyyy-MM-ddTHH:mm:ss).
amountPersons: Количество человек, для которых требуется зал.
Тело запроса:
  {
    "id": 1,
    "name": "Конференц-зал A",
    "capacity": 50,
    "priceHour": 100
  }

# 3. Добавить новый зал
HTTP метод: POST
URL: /api/ConferenceRoom

Этот метод позволяет добавить новый конференц-зал.

Тело запроса
{
  "name": "Название",
  "capacity": int,
  "priceHour": int
}

# 4. Удалить зал по ID
HTTP метод: DELETE
URL: /api/ConferenceRoom/{id}

Этот метод позволяет удалить конференц-зал по его идентификатору.

Параметры запроса
id: ID конференц-зала, который нужно удалить.

# 5. Редактировать зал
HTTP метод: PUT
URL: /api/ConferenceRoom

Этот метод позволяет редактировать существующий конференц-зал.

Параметры запроса
id: ID конференц-зала, который нужно обновить.
Тело запроса
{
  "name": "Название",
  "capacity": int,
  "priceHour": int
}

6.Получить все услуги с пагинацией
HTTP метод: GET
URL: /api/Service?page={page}&pageSize={pageSize}

Этот метод позволяет получить список всех услуг с поддержкой пагинации. Вы можете указать номер страницы и количество элементов на странице.

page: Номер страницы для получения (по умолчанию 1).
pageSize: Количество услуг на странице (по умолчанию 5).

Успешный ответ:
[
  {
    "id": 1,
    "name": "Услуга A",
    "description": "Описание услуги A"
  },
  {
    "id": 2,
    "name": "название",
    "description": "Описание услуги B"
  },
]
