# To-Do List Backend

## Fase 1: Base de Datos y Modelos
- [X] Crear tabla `users` (id, email, password_hash, rol).
- [X] Crear tabla `projects` (id, nombre, descripción, fecha_inicio, fecha_fin, admin_id).
- [X] Crear tabla `tasks` (id, project_id, título, descripción, estado, prioridad, asignado_id, fecha_límite).
- [X] Crear tabla `task_dependencies` (id, tarea_origen, tarea_destino).

## Fase 2: Autenticación
- [X] Implementar endpoint `POST /auth/register` (hash con bcrypt).
- [X] Implementar endpoint `POST /auth/login` (generar JWT).

## Fase 3: API Básica
- [ ] Crear endpoint `GET /projects` (lista de proyectos del usuario).
- [ ] Crear endpoint `POST /projects` (nuevo proyecto, solo admin).
- [ ] Crear endpoint `GET /projects/:id/tasks` (tareas de un proyecto).
- [ ] Crear endpoint `POST /projects/:id/tasks` (nueva tarea).
- [ ] Crear endpoint `PATCH /tasks/:id` (actualizar tarea).
- [ ] Crear endpoint `DELETE /tasks/:id` (eliminar tarea).

## Fase 4: Colaboración en Tiempo Real
- [ ] Configurar Socket.IO en el servidor y emitir eventos.
- [ ] Añadir evento `task-moved` al actualizar una tarea (`PATCH /tasks/:id`).
- [ ] Implementar evento `task-assigned` al asignar una tarea a un usuario.

## Fase 5: Funciones Intermedias
- [ ] Añadir endpoint `POST /tasks/:id/comments` para comentarios.
- [ ] Crear endpoint `GET /projects/:id/progress` para calcular % de avance.
- [ ] Configurar Bull con Redis para enviar notificaciones por email (usando Nodemailer).

## Fase 6: Funciones Avanzadas
- [ ] Añadir validación de dependencias en `PATCH /tasks/:id` (no completar si dependencias están pendientes).
- [ ] Crear endpoint `GET /projects/:id/gantt` para datos del gráfico Gantt.
- [ ] Implementar endpoint `POST /projects/:id/invite` para invitar miembros (generar enlace o enviar email).
- [ ] Añadir soporte para reglas automáticas (ej. archivar tareas completadas tras X días) con Bull.


## Iniciar el proyecto

1. Cambiar el nombre del archivo `.env.template` a `.env` y agregar las variables de entorno.
2. Ejecutar el archivo `db_setup.sql` para crear la base de datos.