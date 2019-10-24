using System;
using System.IO;
using System.Text;

class MainClass {
	static Biblioteca biblio = new Biblioteca("Anteiku","40.110-050");

  public static void Main (string[] args){
		bool programa = true;
		
		while (programa == true){
		programa = MainClass.Login();
		biblio.GravarLivros();
		if (programa == true){
		MainClass.interacoes();
		}
		}
		Console.WriteLine("Obrigado por utilizar o nosso sistema.");
	}

	public static bool Login(){
	
		bool condicao = false;
		while ( condicao == false){
			Console.WriteLine("Deseja realizar login(1), cadastro(2) ou sair(3): ");
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
				if (login ==3){
					return false;
				}
				else{
					Console.WriteLine("Comando inválido");
				}
			}

		}
		return true;
  }

	public static void interacoes(){
		Console.WriteLine(biblio.getUsuarioLogado().getNome());
		bool condicao = true;
		while ( condicao == true){
			Console.WriteLine("Deseja Alugar um livro(1), Buscar um livro(2),Ver seus livros(3) , devolver um livro(4), doar livro para a biblioteca(5)ver a descrição de um livro ou deslogar(7):");
			int decisao = int.Parse(Console.ReadLine());

			switch (decisao){

				case 1:
				Console.WriteLine("Digite o nome do livro no qual deseja alugar: ");
				string nomeLivroAlugar= Console.ReadLine();
				Console.WriteLine(biblio.getUsuarioLogado().AlugarLivro(nomeLivroAlugar,biblio));
				break;

				case 2:
				Console.WriteLine("Livros Disponíveis para alugar:");
				biblio.MostrarLivros();

				break;

				case 3:
				Console.WriteLine("Os livros que voçê possui são :");
				biblio.getUsuarioLogado().MostrarLivrosUsuario();
				break;

				case 4:
				Console.WriteLine("Qual o nome no livro que deseja devolver: ");
				string livroDevolver = Console.ReadLine();
				biblio.getUsuarioLogado().DevolverLivro(livroDevolver,biblio);
				break;

				case 5: // Adicionar livro
				Console.WriteLine("Para doar o livro insira os dados: ");
				Console.WriteLine("Digite o nome do livro ");
				string nomeLivro = Console.ReadLine();
				Console.WriteLine("Digite o gênero do livro");
				string genero = Console.ReadLine();
				Console.WriteLine("Digite o autor do livro ");
				string autor = Console.ReadLine();
				Console.WriteLine("Digite a faixa etária do livro ");
				int faixa = int.Parse(Console.ReadLine());
				Livro livro = new Livro(nomeLivro,genero,autor,faixa);
				biblio.AdicionarLivro(livro);
				break;

				case 6:
				Console.WriteLine("Digite o nome do livro no qual deseja obter uma melhor descrição ");
				string descr = Console.ReadLine();
				//biblio.getLivros()(MostrarDescricao(descr,biblio));


				break;
				
				case 7:
				bool b = false;
				biblio.getUsuarioLogado().setLogado(false);
				condicao = false;
				break;
			}
		}
	}
} 
