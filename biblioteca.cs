using System;
using System.IO;
using System.Text;
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
	public void RealizarCadastro(Usuario user){
		for(int x=0;x < usuarios.Length;x++){
			if(usuarios[x] == null){
				usuarios[x] = user;
				Console.WriteLine("Adicionou");
				break;
			}
		}
	}

	public bool AutentificarUsuario(string nome){	

		for(int x=0; x< usuarios.Length;x++){
			if(usuarios[x] != null){
				if(usuarios[x].getNome() == nome){
					usuarios[x].setLogado(true);
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
				Console.WriteLine("Adicionou");
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
		
	//gravar os livros num txt
	public void GravarLivros(){
			
		FileStream escritaArquivo = new FileStream("dadosLivro.txt",FileMode.Open,FileAccess.Write);
			
		StreamWriter sw = new StreamWriter(escritaArquivo,Encoding.UTF8);
		sw.Close();
		escritaArquivo.Close();
			
		FileStream leituraArquivo = new FileStream("dadosLivro.txt",FileMode.Open,FileAccess.Read);
			
		StreamReader sr = new StreamReader(leituraArquivo,Encoding.UTF8);

		sr.Close();
		leituraArquivo.Close();
		Console.Clear();			
	}
}