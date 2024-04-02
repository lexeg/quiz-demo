# quiz-demo

# создать образ backend-приложения
```sh
docker build -t demo-quiz .
```
# запустить экземпляр образа
```sh
docker run -it --rm -p 5000:8080 --name my-demo-quiz demo-quiz
```

# создал контейнер сервера PostgreSQL
```sh
docker run -d --name quiz-demo-pg-container -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=orcl postgres
```

# создал контейнер PgAdmin
```sh
docker run -d --name quiz-demo-pgadmin-container -p 5050:80 --env PGADMIN_DEFAULT_EMAIL=pgadmin@mail.com --env PGADMIN_DEFAULT_PASSWORD=admin dpage/pgadmin4
```

# запуск с docker-compose
```sh
docker-compose up
```
Страница Swagger после запуска через docker-compose: http://localhost:5000/swagger/index.html

# создал EF-классы для работы с БД (database-first)
```sh
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Username=postgres;Password=orcl;Database=QuizDB;" Npgsql.EntityFrameworkCore.PostgreSQL
```

# Add initial migration
```sh
cd .\EntityFrameworkExample.Migrations\
dotnet ef migrations add InitialCreate
```

# Build migration script
```sh
dotnet ef migrations script --idempotent --project QuizDemo.DataAccess.Migrations --startup-project QuizDemo.DataAccess.Migrations --output Databases/QuizDB.sql
```

# Frontend
### Installation

```sh
npm i
```

### Сборка проекта

```sh
npm run build
```

### Deploy на GitHub pages

```sh
npm run deploy-github
```

### Страница проекта (в работе)

[quiz-demo](https://lexeg.github.io/quiz-demo/)

### Ссылка на angular-cli-ghpages

[angular-cli-ghpages](https://www.npmjs.com/package/angular-cli-ghpages)
