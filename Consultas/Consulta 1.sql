--Mediante la relacion entre las tablas Cliente y Pedido
--muestra los clientes de Santo Domingo que han realizado pedidos
SELECT * FROM Cliente INNER JOIN Pedido 
ON Cliente.Id = Pedido.IdCliente WHERE poblacion = 'Santo Domingo';



--Mediante la relacion entre las tablas Cliente y Pedido
--muestra los clientes que ha pagado al 'Contado'
SELECT * FROM Pedido INNER JOIN Cliente 
ON Pedido.IdCliente = Cliente.Id WHERE formaPago = 'Contado';