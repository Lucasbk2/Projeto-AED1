using System;

class MainClass {
		static Biblioteca biblio = new Biblioteca("Anteiku","40.110-050");
		

  public static void Main (string[] args) {
		MainClass.Login();
		Console.WriteLine("Fim");
		
	}
	public static void Login(){
		bool condicao = false;
		while ( condicao == false){
			Console.WriteLine("Deseja realizar login(1) ou cadastro(2): ");
			int login = int.Parse(Console.ReadLine());

			//usuario.Login();
			if(login == 1){
				Console.WriteLine("Login");
				Console.WriteLine("Digite seu nome:");
				string senha = Console.ReadLine();
				Console.WriteLine(biblio.AutentificarUsuario(senha));
					
					
				
				condicao = true;
			}

			else{
				if (login == 2){
					//usuario.CadastrarUsuario();
					Console.WriteLine("Cadastro");
					Console.WriteLine("Digite seu nome: ");
					string nome = Console.ReadLine();
					

					Console.WriteLine("Digite sua idade: ");
					int idade = int.Parse(Console.ReadLine());

					Console.WriteLine("Digite seu CPF: ");
					string cpf = Console.ReadLine();
					Usuario user = new Usuario(nome,idade,cpf);
					//biblio.setUsuario(user);
					biblio.RealizarCadastro(user);					
				}

				else{
					Console.WriteLine("Comando inválido");
				}
			}
		}
  }
} 
