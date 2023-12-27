using System;
using System.Collections.Generic;

public class Contactos {
	
	public int IdContacto {get; set;}
	public int IdUsuario {get; set;}
	public string Nombre {get; set;}
	public string Apellido {get; set;}
	public byte Edad {get; set;}
	public string Email {get; set;}
	public string Telefono {get; set;}
	public string Genero {get; set;}
	public string Direccion {get; set;}
	public string Ciudad {get; set;}
	
	public List<string> ListaGeneros = new List<string>(){"Masculino", "Femenino"};
	public List<string> ListaCiudades = new List<string>(){"Santo Domingo", "Santiago", "La Vega", "Puerto Plata", "Samana"};
	
	public enum Generos
	{
		Masculino = 0,
		Femenino = 1,
	}
	
	public enum Ciudades
	{
		SantoDomingo = 0,
		Santiago = 1,
		LaVega = 2,
		PuertoPlata = 3,
		Samana = 4,
	}
	
	public Contactos()
	{
		this.IdContacto++;
		this.IdUsuario = 1;
		this.Nombre = "Default";
		this.Apellido = "Default";
		this.Edad = 1;
		this.Email = "default@correo.com";
		this.Telefono = "000-000-0000";
		this.Genero = ListaGeneros[(int)Generos.Masculino];
		this.Direccion = "Address";
		this.Ciudad = ListaCiudades[(int)Ciudades.SantoDomingo];
	}
	
	
			
}

public class Usuarios{
	public List<string> NombreUsuario {get; set;} = new List<string>();
	public List<Contactos> Contacto {get; set;} = new List<Contactos>();
	
	
	public void NewUser(string Name){
			
		this.NombreUsuario.Add(Name);
	}
	
	public void NewContact(int id,int Usuario,string Name, string LastName, byte Age, string Email, 
						   string Telefono, Contactos.Generos Genero, string Direccion, Contactos.Ciudades Ciudad ){
		
		Contactos Utility = new Contactos();
		
		Contactos Contact = new Contactos{
			
			IdUsuario = Usuario,
			IdContacto = id,
			Nombre = Name,
			Apellido = LastName,
			Edad = Age,
			Email = Email,
			Telefono = Telefono,
			Genero = Utility.ListaGeneros[(int)Genero],
			Direccion = Direccion,
			Ciudad = Utility.ListaCiudades[(int)Ciudad]
		};
		
		this.Contacto.Add(Contact);
		
	}
	
	
}
					
public class Program
{
	
	public static void Main()
	{
		Usuarios Usuario = new Usuarios();
		Usuario.NewUser("");
		Usuario.NewUser("Maria Hernandez");
			Usuario.NewContact(1,1,"Jose","Perez", 24, "perez24@hotmail.com","809-544-1212",Contactos.Generos.Masculino,"Duarte 77, Los minas",Contactos.Ciudades.SantoDomingo);
			Usuario.NewContact(2,1,"Pablo","Garcia", 38, "Garcia@gmail.com","809-645-3333",Contactos.Generos.Masculino,"Duarte #32, Sabana",Contactos.Ciudades.LaVega);
		
		Usuario.NewUser("Pedro Hernandez");
			Usuario.NewContact(1,2,"Marcos","Guzman", 36, "Guzman@hotmail.com","809-888-7777",Contactos.Generos.Masculino,"Federico pance #77, Coquitos",Contactos.Ciudades.SantoDomingo);
			Usuario.NewContact(2,2,"Julia","Betone", 64, "Betone@gmail.com","809-123-4567",Contactos.Generos.Femenino,"Duarte Cabral #18, Villa Duarte",Contactos.Ciudades.Samana);
			Usuario.NewContact(3,2,"Cesar","Paez", 72, "Paez@gmail.com","829-999-1111",Contactos.Generos.Masculino,"Reparto #02, Los minas",Contactos.Ciudades.PuertoPlata);
		
		Usuario.NewUser("Joshua Guzmán");
			Usuario.NewContact(1,3,"Xiomara","Morel", 71, "Morel@hotmail.com","809-888-7777",Contactos.Generos.Femenino,"Federico pance #77, Coquitos",Contactos.Ciudades.Santiago);
			Usuario.NewContact(2,3,"Naty","Jimenez", 42, "Jimenez@gmail.com","809-000-0000",Contactos.Generos.Femenino,"Duarte Cabral #88, Isabelita",Contactos.Ciudades.Samana);
			Usuario.NewContact(3,3,"Gabriel","Santos", 13, "Santos@gmail.com","829-369-7532",Contactos.Generos.Masculino,"Cajuil 52, Los minas",Contactos.Ciudades.SantoDomingo);
			Usuario.NewContact(4,3,"Ismael","Paredes", 10, "Paredes@gmail.com","829-951-0159",Contactos.Generos.Masculino,"Popote #02, Herrera",Contactos.Ciudades.PuertoPlata);
			Usuario.NewContact(5,3,"Rocky","Guzman", 3, "Guzman@gmail.com","829-829-0123",Contactos.Generos.Masculino,"Milla #100, Mella",Contactos.Ciudades.LaVega);
		
		
		Console.WriteLine("Seleccione un usuario de la lista para visualizar su lista de contactos:");
		int count = 0;
		foreach(var user in Usuario.NombreUsuario){
			
			if(user!=""){
				Console.WriteLine(count + " - " + user);
			}
			count++;
		}
		
		Console.WriteLine("\n");
		
		int SelUsuario = int.Parse(Console.ReadLine());
		
		Console.WriteLine("\nUsuario: " + (Usuario.NombreUsuario[SelUsuario]).ToUpper());
		Console.WriteLine("Cantidad de Contactos: " + Usuario.Contacto.FindAll(t => t.IdUsuario==SelUsuario).Count);
		Console.WriteLine("*******************************************************");
		
		var Listado = Usuario.Contacto.FindAll(t => t.IdUsuario==SelUsuario).ToArray();
		
		foreach(var item in Listado){
			Console.WriteLine("\nContacto #: " + item.IdContacto);
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("- Nombre: " + item.Nombre + "\n- Apellido: " + item.Apellido + "\n- Edad: " + 
								  item.Edad + "\n- Email: " + item.Email + "\n- Telefono: " + item.Telefono +
								 "\n- Genero: " + item.Genero + "\n- Dirección: " + item.Direccion + 
								 "\n- Ciudad: " + item.Ciudad);
		}
		
		
	}
		
		
	
}