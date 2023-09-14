1. Ejecutar migraciones

```cs
  > dotnet ef database update
```

2. Montar contenedor de PostgreSQL y pgadmin,
   se debe ejecutar el archivo ./docker.up.sh en linux o
   ejecutar el siguiente comando usando docker-compose

```cs
  > docker-compose -f ./docker-compose-local.yml up -d
```

3. Compilar proyecto

```cs
  > dotnet build
```

4. Ejecutar proyecto

```cs
  > dotnet run
```
