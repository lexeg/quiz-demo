# quiz-demo

# создать образ backend-приложения
docker build -t demo-quiz .
# запустить экземпляр образа
docker run -it --rm -p 5000:8080 --name my-demo-quiz demo-quiz

# создал контейнер сервера PostgreSQL
docker run -d --name quiz-demo-pg-container -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=orcl postgres

# создал контейнер PgAdmin
docker run -d --name quiz-demo-pgadmin-container -p 5050:80 --env PGADMIN_DEFAULT_EMAIL=pgadmin@mail.com --env PGADMIN_DEFAULT_PASSWORD=admin dpage/pgadmin4

# создал EF-классы для работы с БД (database-first)
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Username=postgres;Password=orcl;Database=QuizDB;" Npgsql.EntityFrameworkCore.PostgreSQL

# Add initial migration
cd .\EntityFrameworkExample.Migrations\
dotnet ef migrations add InitialCreate

# Build migration script
dotnet ef migrations script --idempotent --project QuizDemo.DataAccess.Migrations --startup-project QuizDemo.DataAccess.Migrations --output Databases/QuizDB.sql