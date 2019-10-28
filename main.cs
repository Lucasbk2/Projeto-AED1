using System;
using System.IO;
using System.Text;

class MainClass {
	static Biblioteca biblio = new Biblioteca("Anteiku","40.110-050");
	
  public static void Main (string[] args){
		Console.WriteLine("---------------------------------------");
		Console.WriteLine("|        Bem vindo a Anteiku !        |");
		Console.WriteLine("---------------------------------------");
		Console.WriteLine("");
		Console.WriteLine("                 Menu                  ");
		int programa = 1;
		biblio.LerLivros();
		biblio.LerUsuarios();	
		biblio.LerLivroUsuario();

		while (programa <= 3){
			programa = MainClass.Login();
			if (programa == 2){
				MainClass.interacoes();
			}
			if(programa == 3){
				MainClass.interacoesADM();
			}
		}

		biblio.GravarLivros();
		biblio.GravarUsuarios();
		biblio.GravarLivrosUsuario();
		Console.WriteLine("---------------------------------------");
		Console.WriteLine(" Obrigado por utilizar o nosso sistema. ");
		Console.WriteLine("---------------------------------------");
	}
		
	public static int Login(){

		bool condicao = false;

		while ( condicao == false){
			Console.WriteLine("---------------------------------------");
			Console.WriteLine("| 1 - Login | 2 - Cadastro | 3 - Sair |");
			Console.Write("---------------------------------------\n-> ");
			int login = int.Parse(Console.ReadLine());

			//usuario.Login();
			if(login == 1){
				Console.WriteLine("Login");
				Console.WriteLine("");
				Console.WriteLine("---------------------------------------");
				Console.Write("| Digite seu nome: ");
				string senha = Console.ReadLine();
				Console.Write("| Digite seu CPF: ");
				string cep = Console.ReadLine();
				Console.WriteLine("---------------------------------------");

				if (biblio.AutentificarUsuarioADM(senha,cep) == true){
					Console.WriteLine("Usuario autêntificado.");
					return 3;
				}
				else{
					if (biblio.AutentificarUsuario(senha,cep) == true){
						Console.WriteLine("Usuario autêntificado.");
					condicao = true;
					}
					else{
					Console.WriteLine("-> Login Inválido ! ");
					}
				}
			}

			else{
				if (login == 2){
					//usuario.CadastrarUsuario();
					Console.WriteLine("");
					Console.WriteLine("               Cadastro         ");					
					Console.WriteLine("---------------------------------------");

					Console.Write("| Digite seu nome: ");
					string nome = Console.ReadLine();
					
					Console.Write("| Digite sua idade: ");
					int idade = int.Parse(Console.ReadLine());
					
					Console.Write("| Digite seu CPF: ");
					string cpf = Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Usuario user = new Usuario(nome,idade,cpf,false);
					
					//biblio.setUsuario(user);
					biblio.RealizarCadastro(user);
					Console.WriteLine("-> Cadastro Realizado !");
					Console.WriteLine("");					
				}
				if (login ==3){
					return 4;
				}
				if(login < 1  || login >4){
					Console.WriteLine("-> Comando Inválido !");
				}
			}

		}
		return 2;
  }

	public static void interacoes(){
		Console.WriteLine(biblio.getUsuarioLogado().getNome());
		bool condicao = true;
		while ( condicao == true){
			Console.WriteLine("");
			Console.WriteLine("|                  Opções             |");
			Console.Write("---------------------------------------");
			Console.Write("\n| 1 - Alugar Livro                    |\n| 2 - Buscar Livro                    |\n| 3 - Livros Alugados                 |\n| 4 - Devolver Livro                  |\n| 5 - Ver Descrição                   |\n| 6 - Deslogar                        |\n");
			Console.WriteLine("---------------------------------------");
			Console.Write("-> ");
			int decisao = int.Parse(Console.ReadLine());
			Console.WriteLine("");
			
			switch (decisao){
				case 1:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Digite o nome do livro no qual deseja alugar: ");
					string nomeLivroAlugar= Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Console.WriteLine(biblio.getUsuarioLogado().AlugarLivro(nomeLivroAlugar,biblio));
				break;
				
				case 2:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Livros Disponíveis para alugar:");
					biblio.MostrarLivros();
					Console.WriteLine("---------------------------------------");
				break;

				case 3:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Os livros que voçê possui são :");
					biblio.getUsuarioLogado().MostrarLivrosUsuario();
					Console.WriteLine("---------------------------------------");
				break;

				case 4:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Qual o nome no livro que deseja devolver: ");
					string livroDevolver = Console.ReadLine();
					Console.WriteLine(biblio.getUsuarioLogado().DevolverLivro(livroDevolver,biblio));
					Console.WriteLine("---------------------------------------");
				break;

				case 5:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Informe o nome do Livro: ");
					string descr = Console.ReadLine();
					for(int i = 0;i < biblio.getLivros().Length;i++ ){
						if (biblio.getLivros()[i] != null){
							if (biblio.getLivros()[i].getNome() == descr){
								biblio.getLivros()[i].MostrarDescricao(descr,biblio);
							}
						}	
					}
					Console.WriteLine("---------------------------------------");
				break;

				case 6:
					biblio.getUsuarioLogado().setLogado(false);
					condicao = false;
				break;
				
			}
		}
	}
	public static void interacoesADM(){

		bool condicao = true;

		while(condicao == true){
			Console.WriteLine("");
			Console.Write("---------------------------------------");
			Console.Write("\n| 1 - Adicionar novo usuario administrador \n| 2 - Adicionar Livro a biblioteca \n| 3 - Alterar faixa etaria de um livro \n| 4 - Mostrar livros presentes na biblioteca \n| 5 - Mostrar Descrição de um livro\n| 6 - Fazer Logoff\n");
			Console.WriteLine("---------------------------------------");
			Console.Write("-> ");
			int decisao = int.Parse(Console.ReadLine());
			Console.WriteLine("");

			switch(decisao){
				case 1:
					Console.WriteLine("Cadastro");
					Console.WriteLine("");
					Console.WriteLine("---------------------------------------");
					Console.Write("| Digite seu nome de funcionário: ");
					string nome = Console.ReadLine();
					
					Console.Write("| Digite sua idade de funcionário: ");
					int idade = int.Parse(Console.ReadLine());
					
					Console.Write("| Digite seu CPF de funcionário: ");
					string cpf = Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Usuario user = new Usuario(nome,idade,cpf,true);
					//biblio.setUsuario(user);
					biblio.RealizarCadastro(user);
					Console.WriteLine("");
				break;

				case 2:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Para adicionar o livro a biblioteca insira os dados: ");
					Console.WriteLine("---------------------------------------");
					Console.Write("| Digite o nome do livro: ");
					string nomeLivro = Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Console.Write("| Digite o gênero do livro: ");
					string genero = Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Console.Write("| Digite o autor do livro: ");
					string autor = Console.ReadLine();
					Console.WriteLine("---------------------------------------");
					Console.Write("| Digite a faixa etária do livro: ");
					int faixa = int.Parse(Console.ReadLine());
					Console.WriteLine("---------------------------------------");
					Livro livro = new Livro(nomeLivro,genero,autor,faixa);
					biblio.AdicionarLivro(livro);
				break;

				case 3:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Digite o nome do livro no qual deseja mudar a faixa etária: ");
					string livroNf = Console.ReadLine();
					for(int y = 0;y < biblio.getLivros().Length;y++ ){
						if (biblio.getLivros()[y] != null){
							if (biblio.getLivros()[y].getNome() == livroNf){
								Console.WriteLine("Qual a nova faixa etário desejada: ");
								int novaFaixa = int.Parse(Console.ReadLine());
								biblio.getLivros()[y].AlterarFaixaEtaria(novaFaixa);
							}
						}	
					}
					Console.WriteLine("---------------------------------------");
				break;

				case 4:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Livros Disponíveis para alugar na biblioteca :");
					biblio.MostrarLivros();
					Console.WriteLine("---------------------------------------");
				break;

				case 5:
					Console.WriteLine("---------------------------------------");
					Console.WriteLine("Informe o nome do Livro: ");
					string descr = Console.ReadLine();

					for(int i = 0;i < biblio.getLivros().Length;i++ ){
						if (biblio.getLivros()[i] != null){
							if (biblio.getLivros()[i].getNome() == descr){
								biblio.getLivros()[i].MostrarDescricao(descr,biblio);
							}
						}	
					}
					Console.WriteLine("---------------------------------------");
				break;

				case 6:
					Console.WriteLine("Logoff realizado com sucesso: ");
			
					condicao = false;
				break;
			}					
		}
	}
} 
