   M S B A M L   `   `   `  ����P  LWPF_DB_GestionPedidos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPF_DB_GestionPedidosWPF_DB_GestionPedidos  5   	   &     WPF_DB_GestionPedidos.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WPF_DB_GestionPedidos     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��5	   	   $	��800��5
   	   .��5      � .+�5   
    � -   5        $��	MainFrame��5        � NavigationUIVisibility$ Hidden=�5      �� 5   
   $
��Auto=�6   .��5      �� .+�5      � 
�������$��50��6)    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��* �6+   �� 5      $��* �6+   .+�5      �� -   5        $��IrFormularioCliente��5      $��0��5      $��Formulario Cliente��5      $��30��5      $��Center=�5      $��Center=�5      $��17(�5      $��	ExtraBold"�5      $��Normal$�5       
�������
�������5"      �� 5$      -   5        $��IrFormularioArticulo��5$      $��1��5&      $��Formulario Articulo��5'      $��30��5(      $��Center=�5)      $��Center=�5*      $��17(�5+      $��	ExtraBold"�5,      $��Normal$�5-      
�������
�������5/      51      �� 52      $��Clientes��6   $��30(�53      $
��Bold"�54      $��Center=�55      �� 56      -   5        $��ListaCliente��56      $	��300��57      $	��300��58      5;      �� 5<       �� Orientation$ 
Horizontal=�6   $��Center=�66   $	��0,0q�5=      .+�5>      �� -   5        $��actualizarCliente��5>      $��Actualizar Cliente��5@      
����ح�$
��Bold"�5B      $��
0,40,10,50q�5C      $��30��5D      $	��250��5E      �� 5F      -   5        $��EliminaCliente��5F      $��Elimina Cliente��5H      
����ح�$
��Bold"�5J      $��
10,40,0,50q�5K      $��30��5L      $	��250��5M      5O      �� 5P      
�������$��Center=�5Q      $��0,0,0,0q�5R      �� 5S      $\�VSeleccione un cliente en la tabla de cliente y pulse el botón para añadir un pedido.��6   5U      �� 5V      -   5        $��AgregarPedido��5V      $��Agregar Pedido��5X      
����ح�$
��Bold"�5Z      $��	10,5,0,50q�5[      $��30��5\      $	��250��5]      �� 5^      $��Pedidos realizados��6   $��30(�5_      $
��Bold"�5`      $��Center=�5a      $��0,40,0,0q�5b      �� 5c      -	   5        $��ListaPedidos��5c      $	��300��5d      $	��300��5e      �� 5f      $��	Articulos��6   $��30(�5g      $
��Bold"�5h      $��Center=�5i      $��0,40,0,0q�5j      �� 5k      -
   5        $��ListaArticulos��5k      $	��300��5l      $	��300��5m      �� 5n      $ 
Horizontal=�6   $��Center=�5o      $	��0,0q�5p      .+�5q      �� -   5        $��actualizarArticulo��5q      $��Actualizar Articulo��5s      
����ح�$
��Bold"�5u      $��
0,40,10,50q�5v      $��30��5w      $	��250��5x      �� 5y      -   5        $��EliminaArticulo��5y      $��Elimina Articulo��5{      
����ح�$
��Bold"�5}      $��
10,40,0,50q�5~      $��30��5      $	��250��5�      5�      �� 5�      $��Todos los Pedidos��6   $��30(�5�      $
��Bold"�5�      $��Center=�5�      $��0,40,0,0q�5�      � 5�      $	��300��6   $��Center=�6#   $��	0,0,100,0q�5�      .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��Cantidad de pedidos: ��6    $��Medium&�5�       
�������5�       �� 5�      -   5        $��Cantidad��5�       $��0��5�       $��Medium&�5�       
�������5�       5�      5�      �� 5�      -   5        $��PedidoCompletos��5�      $	��300��5�      $	��450��5�      �� 5�      -   5        $��EliminarPedido��5�      $��Eliminar Pedido��5�      
����ح�$
��Bold"�5�      $��	0,40,0,50q�5�      $��30��5�      $	��250��5�      5�      5�      5�      5�      