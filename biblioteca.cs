using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Biblioteca{
	
	//Declaração dos Atributos
	private string nome;
	private string cep;
	private Usuario[] usuarios = new Usuario[50];
	private Livro[] livros = new Livro [100];
		
	//Construtores
	public Biblioteca(string n, string c){
		this.nome = n;
		this.cep = c;
	}
	
	public Biblioteca(){
		this.nome = "";
		this.cep = "";
	}

	//Métodos get/set
	public string getNome(){
		return nome;
	}
	public void setNome(string n){
		nome = n;
	}
	

	public void setUsuario(Usuario user){
		usuarios[0] = user;
	}

	public string getCep(){
		return cep;
	}
	public void setCep(string c){
		cep = c;
	}
	

	public Livro[] getLivros(){
		return this.livros;
	}
	public void setLivros(Livro[] livro){
		this.livros = livro;
	}
	

	public Usuario getUsuarioLogado(){
		for(int x=0; x< usuarios.Length;x++){
			if(usuarios[x] != null){
				if(usuarios[x].getLogado() == true){
					return usuarios[x];
				}
			}	
		}
		return null;
	}

	//Métodos Funcionais
	public void  RealizarCadastro(Usuario user){
		for(int x=0;x < usuarios.Length;x++){
			if(usuarios[x] == null){
				usuarios[x] = user;
				break;
			}
		}
	}

	public bool AutentificarUsuario(string nome,string oCep){	
		for(int x=0; x< usuarios.Length;x++){
			if(usuarios[x] != null){
				if(usuarios[x].getNome() == nome && usuarios[x].getCpf() == oCep){
					usuarios[x].setLogado(true);
					return true;
				}
			}
		}
		return false;
	}	


	public bool AutentificarUsuarioADM(string nome,string oCep){
		for(int x=0; x< usuarios.Length;x++){
			if(usuarios[x] != null){
				if(usuarios[x].getNome() == nome && usuarios[x].getCpf() == oCep && usuarios[x].getAdm() == true){
					return true;
				}
			}
		}
		return false;
	}
	

	public void AdicionarLivro(Livro livro){
		for(int x=0;x < livros.Length;x++){
			if(livros[x] == null){
				livros[x] = livro;
				Console.WriteLine("-> Livro Adicionado");
				break;
			}	
		}
	}


	public void MostrarLivros(){
		for(int x=0; x < livros.Length;x++){
			if(livros[x] != null){
				Console.WriteLine(livros[x].getNome());
			}
		}
	}
		



	public void LerLivros(){
		FileStream leituraArquivo = new FileStream("dadosLivro.txt",FileMode.Open,FileAccess.Read);
		StreamReader sr = new StreamReader(leituraArquivo,Encoding.UTF8);
		while(!sr.EndOfStream){
			string linha = sr.ReadLine();
			string[] vetorInfo = linha.Split(";");
			string varNome = vetorInfo[0];
			string varGenero = vetorInfo[1];
			string varAutor = vetorInfo[2];
			int varFaixa_etaria = int.Parse(vetorInfo[3]);

			Livro livro = new Livro(varNome,varGenero,varAutor,varFaixa_etaria);

			for (int i=0;i<livros.Length;i++){
				if(livros[i] == null){
					livros[i] = livro;
					break;
				}
			}
		}	
		sr.Close();
		leituraArquivo.Close();
	}

	//Setor de arquivos
	public void GravarLivros(){
		
		string variavel;
		List<string> todasLinhas = new List<string>();
		for(int x = 0;x<livros.Length;x++){
			if (livros[x] != null){
			
				variavel = "";
				variavel += livros[x].getNome() + ";";
				variavel += livros[x].getGenero() + ";";
				variavel += livros[x].getAutor() + ";";
				variavel += livros[x].getFaixa_etaria();
				todasLinhas.Add(variavel);

			}
		}
		File.WriteAllLines("dadosLivro.txt", todasLinhas);

	}


	public void GravarUsuarios(){
		string userDoido;
		List<string> todasLinhas = new List<string>();
		for(int x = 0; x < usuarios.Length; x++){
			
			if (usuarios[x] != null){
				userDoido = "";
				userDoido += usuarios[x].getNome() + ";";
				userDoido += usuarios[x].getIdade() + ";";
				userDoido += usuarios[x].getCpf() + ";";
				userDoido += usuarios[x].getLogado() + ";";
				userDoido += usuarios[x].getAdm();
				todasLinhas.Add(userDoido);

			}	
		}

		File.WriteAllLines("dadosUsuario.txt", todasLinhas);
	}


	public void LerUsuarios(){
		FileStream lerUser = new FileStream("dadosUsuario.txt",FileMode.Open,FileAccess.Read);		
		StreamReader sr = new StreamReader(lerUser,Encoding.UTF8);

		while(!sr.EndOfStream){
			string userDoido2 = sr.ReadLine();
			string[] vetorUser = userDoido2.Split(";");
			string userNome = vetorUser[0];
			int userIdade = int.Parse(vetorUser[1]);
			string userCpf = vetorUser[2];
			bool userBool = bool.Parse(vetorUser[3]);
			bool userAdm = bool.Parse(vetorUser[4]);
			Usuario user = new Usuario(userNome, userIdade, userCpf,userBool, userAdm);

			for (int i = 0; i < usuarios.Length; i++){
				if(usuarios[i] == null){
					usuarios[i] = user;
					break;
				}
			}
		}
		sr.Close();
		lerUser.Close();		
	}

	
	public void GravarLivrosUsuario(){

		List<string> todasLinhas = new List<string>();
		for(int x=0;x<usuarios.Length;x++){
			if(usuarios[x] != null){
				for(int i=0;i<usuarios[x].getLivroUsuario().Length;i++){
					if(usuarios[x].getLivroUsuario()[i] != null){
						
						string valores = "";
						valores += (usuarios[x].getNome()+";");
						valores += (usuarios[x].getCpf()+";");
						valores += (usuarios[x].getLivroUsuario()[i].getNome()+";");
						valores += (usuarios[x].getLivroUsuario()[i].getGenero()+";");
						valores += (usuarios[x].getLivroUsuario()[i].getAutor()+";");
						valores += (usuarios[x].getLivroUsuario()[i].getFaixa_etaria());

						todasLinhas.Add( valores );

					}

				}

			}

		}


		if(todasLinhas.Count == 0){
			File.WriteAllText("dadosLivrosUsuarios.txt", "");
		}else{
			File.WriteAllLines("dadosLivrosUsuarios.txt", todasLinhas);
		}
	}
	public void LerLivroUsuario(){
		FileStream lerUser = new FileStream("dadosLivrosUsuarios.txt",FileMode.Open,FileAccess.Read);		
		StreamReader sr = new StreamReader(lerUser,Encoding.UTF8);

		while(!sr.EndOfStream){
			string variavel = sr.ReadLine();

			string[] vetorInfo = variavel.Split(";");
			string varNomeUser = vetorInfo[0];
			string varCPFuser = vetorInfo[1];
			string varNome = vetorInfo[2];
			string varGenero = vetorInfo[3];
			string varAutor = vetorInfo[4];
			int varFaixa_etaria = int.Parse(vetorInfo[5]);
			Livro livro = new Livro(varNome,varGenero,varAutor,varFaixa_etaria);
			for(int x=0;x<usuarios.Length;x++){
				if(usuarios[x] != null){
					if(usuarios[x].getNome() == varNomeUser && usuarios[x].getCpf() == varCPFuser){
						for(int y = 0 ; y < usuarios[x].getLivroUsuario().Length;y++){
							if(usuarios[x].getLivroUsuario()[y] == null){
								usuarios[x].getLivroUsuario()[y] = livro;
								break;
							}
						}
					}
				}
			}		
		}
		sr.Close();
		lerUser.Close();	

	}

}