CREATE TABLE Departamento(
	IdDepartamento INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(20),
	Descripcion VARCHAR(100)
);

SELECT * FROM Departamento;

CREATE TABLE Empleado(
	IdEmpleado INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
	NombreCompleto VARCHAR(50),
	CorreoElectronico VARCHAR(50),
	FechaNacimiento DATE,
	NumeroTelefono VARCHAR(10),
	DptoIdDpto INT FOREIGN KEY REFERENCES Departamento(IdDepartamento),
	FechaContratación DATE,
	Cargo VARCHAR(20),
	Salario DECIMAL(10,2)
);

SELECT * FROM Empleado;

CREATE TABLE Proyecto(
	IdProyecto INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(20),
	FechaInicio DATE,
	FechaFinalizacion DATE,
	DptoIdDpto INT FOREIGN KEY REFERENCES Departamento(IdDepartamento)
);

SELECT * FROM Proyecto;

CREATE TABLE Rol(
	IdRol INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(20),
	Descripcion VARCHAR(100),
	EmpleadoIdEmpleado INT FOREIGN KEY REFERENCES Empleado(IdEmpleado)
);

SELECT * FROM Rol;

CREATE TABLE Competencia(
	IdCompetencia INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(20),
	Descripcion VARCHAR(100),
	EmpleadoIdEmpleado INT FOREIGN KEY REFERENCES Empleado(IdEmpleado)
);

SELECT * FROM Competencia;

CREATE TABLE Tarea(
	IdTarea INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Descripcion VARCHAR(100),
	Estado VARCHAR(15),
	EmpleadoIdEmpleado INT FOREIGN KEY REFERENCES Empleado(IdEmpleado),
	ProyectoIdProyecto INT FOREIGN KEY REFERENCES Proyecto(IdProyecto)
);

SELECT * FROM Tarea;