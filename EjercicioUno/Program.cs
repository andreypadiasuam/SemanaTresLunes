// See https://aka.ms/new-console-template for more information
/* App: Tareas Pendientes
 * Descripcion: Llevar una lista de tareas pendientes y completadas.
 * Funcionamiento: Agregar tareas, ver tareas, completar tareas (de pendiente a completado), salir.
 */

using EjercicioUno.Model;
using System.Threading;
//Lista de mis objetos

List<Tarea> listaTareas = new List<Tarea>();
   

//Menu
bool menu = true;

do
{
	try
	{
        Console.WriteLine("***APP Recordatorio de Tareas***");
        Console.WriteLine("Indique el numero de la opcion que desea seleccionar:");
        Console.WriteLine("1- Agregar Tarea \n 2- Ver Tareas \n 3- Completar Tareas \n 4-Salir");

        string opcionMenu = Console.ReadLine();

        switch (opcionMenu)
        {
            case "1":
                bool agregarTarea = true;
                while (agregarTarea) 
                {
                    Console.WriteLine("1 - Agregando Tarea \n Agregue la descripcion de la tarea:");
                    Tarea tarea = new Tarea(Console.ReadLine());
                    listaTareas.Add(tarea);
                    Console.WriteLine("Desea agregar mas tareas? \n Responda con si o no.");
                    string validadorTarea = Console.ReadLine();
                    if (validadorTarea.ToUpper() != "SI")
                    {
                        Console.WriteLine("Regresando al menu principal");
                        agregarTarea = false;
                    }
                }
                break;
            case "2":
                Console.WriteLine("2 - Lista de tareas");
                if (listaTareas.Count == 0)
                {
                    Console.WriteLine("Aun no se han agregado tareas.");
                }
                else
                {
                    Console.WriteLine("Lista de tareas completadas.");
                    foreach (Tarea tarea in listaTareas) 
                    { 
                        if (tarea.Estado==true) 
                        {
                            Console.WriteLine(tarea.Descripcion);
                        }
                    }

                    Console.WriteLine("Lista de tareas incompletas.");
                    foreach (Tarea tarea in listaTareas)
                    {
                        if (tarea.Estado != true)
                        {
                            Console.WriteLine(tarea.Descripcion);
                        }
                    }
                }
                break;
            case "3":
                Console.WriteLine("3- Completar Tareas \n Ingrese la descripcion de la tarea a completar");
                string descripcionTarea = Console.ReadLine();
                Tarea tareaEncontrada = listaTareas.FirstOrDefault(tarea => tarea.Descripcion.ToLower() == descripcionTarea.ToLower());
                
                if (tareaEncontrada != null) 
                {
                    tareaEncontrada.Estado = true;
                    Console.WriteLine("La tarea {0} ha sido completado.", tareaEncontrada.Descripcion);
                }
                else
                {
                    Console.WriteLine("No existe una tarea con esa descripcion.");
                }

                break;
            case "4":
                Console.WriteLine("Esta seguro de salir del sistema? \n Responda con si o no");
                string respuestaSalida = Console.ReadLine();
                if (respuestaSalida.ToLower() == "si")
                {
                    Console.WriteLine("Saliendo del sistema. \n Aplicacion finalizada.");
                    menu = false;

                } else if (respuestaSalida.ToLower() == "no") 
                {
                    Console.WriteLine("Regresando al menu principal.");
                }
                else
                {
                    Console.WriteLine("Escriba si o no, regresando al menu principal.");
                }
                break;
            default:
                Console.WriteLine("Ingrese un valor del 1 al 4");
                break;
        }
    }
	catch (Exception e)
	{

        Console.WriteLine("Ha ocurrido el siguiente error: ", e.Message);
    }


} while (menu);
