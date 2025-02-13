*pendiente de pruebas*
# 📌 Task Tracker CLI  

Task Tracker CLI es una aplicación de línea de comandos en **.NET 8** para **gestionar tus tareas** de manera rápida y sencilla.  

✅ **Características:**  
- Agregar, actualizar, eliminar y listar tareas  
- Marcar tareas como "En progreso" o "Completadas"  
- Almacenamiento en JSON  
- Modo interactivo y ejecución directa desde la terminal  

---

## 📜 Instalación  
1️⃣ **Clona el repositorio:**  
```sh
git clone https://github.com/tu-repo/task-tracker-cli.git
cd task-tracker-cli

dotnet build
dotnet run

📌 Lista de Comandos
Comando	Descripción	Ejemplo
add "descripción"	Agrega una nueva tarea	add "Comprar leche"
update <id> "descripción"	Actualiza la descripción de una tarea	update 1 "Comprar leche y pan"
delete <id>	Elimina una tarea por ID	delete 1
mark-in-progress <id>	Marca una tarea como "En progreso"	mark-in-progress 1
mark-done <id>	Marca una tarea como "Completada"	mark-done 1
list	Muestra todas las tareas	list
clear	Limpia la pantalla de la consola	clear
exit	Sale de la CLI	exit
