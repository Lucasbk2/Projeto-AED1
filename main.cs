using System;

class MainClass {
		static Biblioteca biblio = new Biblioteca("Anteiku","40.110-050");
		

  public static void Main (string[] args) {
		MainClass.Login();
		MainClass.interacoes();

		
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
				if (biblio.AutentificarUsuario(senha) == true){
					condicao = true;
					
				}
					else{
						Console.WriteLine("Login inválido");
					}
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
	public static void interacoes(){
			Console.WriteLine(biblio.getUsuarioLogado().getNome());
		bool condicao = true;
		while ( condicao == true){
		Console.WriteLine("Deseja Alugar um livro(1), Reservar um livro(2), Buscar um livro(3), devolver um livro(4), doar livro para a biblioteca(5) ou deslogar");
		int decisao = int.Parse(Console.ReadLine());
		switch (decisao){
			case 1:
			Console.WriteLine("Alugar livro");
			Console.WriteLine("Digite o nome do livro no qual deseja alugar: ");
			Console.WriteLine(biblio.getUsuarioLogado().getNome());
			
			
			break;
			case 2:
			Console.WriteLine("Reservar um livro");
			break;
			case 3:
			Console.WriteLine("Buscar livro");
			break;
			case 4:
			Console.WriteLine("Devolver livro");
			break;
			case 5: // Adicionar livro
			Console.WriteLine("Digite o nome do livro");
			string nomeLivro = Console.ReadLine();
			Console.WriteLine("Digite o gênero do livro");
			string genero = Console.ReadLine();
			Console.WriteLine("Digite o autor do livro");
			string autor = Console.ReadLine();
			Console.WriteLine("Digite a faixa etária do livro");
			int faixa = int.Parse(Console.ReadLine());
			Livro livro = new Livro(nomeLivro,genero,autor,faixa);
			biblio.AdicionarLivro(livro);
			break;
			case 6:
			bool b = false;
			biblio.getUsuarioLogado().setLogado(b);
			break;
		}
		condicao = biblio.getUsuarioLogado().getLogado();
		}

	}
} 
