# API-Person
Pre-requisito NETCORE8

CREATE SCHEMA `test` ;

CREATE TABLE `test`.`person` (
  `id_person` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `lastname` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NULL,
  `identification` VARCHAR(45) NULL,
  `phone` VARCHAR(45) NULL,
  `address` VARCHAR(45) NULL,
  `created_date` DATETIME NULL DEFAULT NOW(),
  `last_modified_date` DATETIME NULL,
  PRIMARY KEY (`id_person`),
  UNIQUE INDEX `id_person_UNIQUE` (`id_person` ASC) VISIBLE);

  En el archivo "Program.cs", esta la configuración del CORS, cambiar el puerto con el que corre el app de react ("crud_person")
  
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
