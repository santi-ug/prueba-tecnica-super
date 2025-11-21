# **Monorepo Prueba Técnica**

Este repositorio organiza en un solo lugar el backend desarrollado en **.NET 9 (C#)** y el frontend construído con **Angular + TailwindCSS**. 

El proyecto está dividido en dos carpetas principales:

* **backend/** – API REST en .NET 9 usando Entity Framework Core con MySQL/MariaDB.
* **frontend/** – Aplicación Angular con TailwindCSS, consumo de la API y vista básica para gestión de tareas.

Se utilizó Docker para contenerizar el proyecto debido a que mi OS está en Arch Linux y herramientas del ecosistema .NET y EF Core podrían cauasr problemas al intentnar correr el proyecto en Windows. 

---

## **1. Requisitos**

### **Backend**

* .NET SDK **9.x**
* MariaDB o MySQL
* Herramienta cliente para la base de datos (DBeaver, HeidiSQL, etc.) -- opcional

### **Frontend**

* Node.js **22.x**
* Angular CLI 18+
* npm 11.6

### **DevOps***
* Docker **28.x**
* Docker Desktop (Windows) 
* Docker Compose **2.x**

---

## **2. Configuración**

El backend utiliza variables de entorno que se pueden ver en `env.example`.

- En caso de utilizar Docker, se reemplazan las variables allí. 
- En caso de **no** utilizar Docker, se reemplaza el nombre de la variable  `` por ``.

---

## **3. Ejecución**

### **3.1. Docker**

1. Clonar repositorio 
```
git clone https://github.com/santi-ug/prueba-tecnica-super.git
```
2. Entrar al directorio
```
cd prueba-tecnica-super
```
3. Abrir Docker Hub 
4. docker compose up --build 
- docker-compose up --build (para v1.x de docker compose)
5. Conectar a base de datos MariaDB en puerto 3307
5.1 Las migraciones se corren automaticamente, en caso tal de que no, ejecutar `docker compose` nuevamente.
6. Usar la aplicación en `https://localhost:4200`


## **3.2. Manual**

### **3.2.1 Base de datos**

Crear una base de datos MariaDB, vacía. Por defecto el backend recibe la base de datos llamada:

```
tasksdb
```

### **3.2.2 Backend (.NET 9)**

Dentro de la carpeta `./backend`
Ejecutar 
```
dotnet run
```

### **3.2.3. Ejecutar migraciones**

El sistema crea automáticamente las tablas al iniciar gracias a:

```csharp
db.Database.Migrate();
```

No se requiere ejecutar comandos de EF Core manualmente.

### **3.2.4. Angular**

Dentro de la carpeta `./frontend`
```
ng serve 
```

La API quedará disponible en:

```
http://localhost:5000
```

Y se podrá visualizar el swagger donde quedó documentado el API:

```
http://localhost:5000/swagger

* `GET /tasks`
* `POST /tasks`
* `PATCH /tasks/:id/toggle`
* `DELETE /tasks/:id`
```

Acceso a:

```
http://localhost:4200
```

La aplicación consume directamente el endpoint del backend (`http://localhost:5000/api/tasks`).

---

## **4. Estructura del repositorio**

```
/
├── backend/            # API .NET 9 (C#)
│   └── ...         
│
├── frontend/           # Angular + TailwindCSS
│   └── ...
│
├── docker-compose.yml    
│
└── README.md
```

---

## **5. Sobre el uso de Docker**

Se preparó una estructura inicial con `docker-compose` para orquestar:

* API .NET
* MariaDB
* Angular


## Retos:

* Errores con `dotnet-ef` por versiones y paquetes no disponibles
* Dependencias debido a manejo de diferentes versiones en Arch Linux





