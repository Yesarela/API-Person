# Instrucciones para correr el API BACKEND.

 Se deberá de instalar las siguientes dependencias; MySQL, .NET Core 8 y configurar el proyecto .NET Core 8 API Backend, siguiendo los siguientes pasos a continuación:

## 1. Instalación de MySQL.

Descarga e instala MySQL Server desde el sitio web oficial de MySQL: [MySQL Downloads.](https://dev.mysql.com/downloads/mysql/)

Durante la instalación, se solicitará configurar una contraseña para el usuario root de MySQL. Es requerido mantener estos datos anotados para configurar la cadena de conexión.

### 1.1 Creación de la BD y tabla a usar

Desde el Mysql WorkBench se deberá abrir la instancia que se configuró en la instalación, crear una BD llamada "test" de preferencia y en ella ejecutar lo siguiente:

```
CREATE SCHEMA test;

CREATE TABLE test.person (
  id_person INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(45) NOT NULL,
  lastname VARCHAR(45) NOT NULL,
  email VARCHAR(45) NULL,
  identification VARCHAR(45) NULL,
  phone VARCHAR(45) NULL,
  address VARCHAR(45) NULL,
  created_date DATETIME NULL DEFAULT NOW(),
  last_modified_date DATETIME NULL,
  PRIMARY KEY (id_person),
  UNIQUE INDEX id_person_UNIQUE (id_person ASC) VISIBLE)
```

## 2. Instalación de .NET Core SDK 8

Descarga e instala el SDK de .NET Core 8 desde el sitio web oficial de .NET: [Descargar de .NET](https://dotnet.microsoft.com/download/dotnet/3.1).

Una vez instalado, ejecutaremos el siguiente comando en la terminal para verificar que esté la versión requerida:

```dotnet --version```

Debería mostrar la versión del SDK de .NET Core instalada.

## 3. Configuración del Proyecto .NET Core 8 API Backend

Clonamos el repositorio que contiene el proyecto API Backend.

Abrímos la solución (.sln) del proyecto en Visual Studio 2022 desde la siguiente ruta:

```..\API-Person\PruebaTecnicaCRUD\```

En el archivo appsettings.json, deberemos de configurar la cadena de conexión a la base de datos MySQL. Debería verse algo así:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=test;user=root;password=;"
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  }
}

```

Reemplazamos la contraseña con la contraseña que se configuró durante la instalación de MySQL.

Ahora abrimos el archivo Program.cs y verificamos la configuración CORS para permitir el acceso desde el puerto en el que se ejecuta tu aplicación de React. Acá nos aseguramos de que el origen coincida con el puerto en el que se ejecutará la aplicación:

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

Ahora ejecutamos desde el Visual Studio, o en su defecto si queremos hacerlo desde la terminal, deberemos ejecutar el siguiente comando:

Abre una terminal en el directorio raíz del proyecto y ejecuta los siguientes comandos para crear la base de datos y ejecutar las migraciones:

```dotnet run```

Esto iniciará nuestra API en el puerto predeterminado y se verá el swagger de la siguiente manera:

[Swagger del API](resourcer/swagger_running.png)
