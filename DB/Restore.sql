RESTORE DATABASE Proyecto
FROM DISK = 'C:\Users\Julio\Desktop\Middleware\DB\ProyectoGru.bak'

WITH MOVE 'Proyecto' TO 'C:\LocalDB\Proyecto.mdf',
MOVE 'Proyecto_log' TO 'C:\LocalDB\Proyecto.ldf',
REPLACE;