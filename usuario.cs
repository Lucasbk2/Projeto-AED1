using System;
using System.IO;
using System.Text;


class Usuario{

	//Declaração dos Metódos
	private string nome;
	private int idade;
	private bool logado;
	private bool adm;
	private string cpf;
	private Livro[] livrosUsuario = new Livro [3];

	//Construtores
	public Usuario(string n, int i, string c){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.logado = false;
		this.adm = false;
	}

	public Usuario(string n, int i, string c,bool a){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.logado = false;
		this.adm = a;
	}
	
	public Usuario(string n, int i, string c,bool log, bool a){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.logado = log;
		this.adm = a;
	}
 
	public Usuario(){
		this.nome = "";
		this.idade = 0;
		this.cpf = "";
		this.logado = false;
	}

	//Métodos get/set
	public string getNome(){
		return nome;
	}
	public void setNome(string n){
		nome = n;
	}

	public int getIdade(){
		return idade;
	}
	public void setIdade(int i){
		idade = i;
	}

	public string getCpf(){
		return cpf;
	}
	public void setCpf(string c){
		cpf = c;
	}
	
	public bool getLogado(){
		return logado;
	}
	public void setLogado(bool b){
		this.logado = b;
	}
	
	public bool getAdm(){
		return adm;
	}
	public void setAdm(bool ad ){
		this.adm = ad;

	}
	public Livro[] getLivroUsuario(){
		return livrosUsuario;
	}


	//Métodos Funcionais
	public string AlugarLivro(string livroSelecionado, Biblioteca bi){
		int numLivros = 0;
		for(int x=0; x < bi.getLivros().Length; x++){
			if(bi.getLivros()[x] != null){

				if(livroSelecionado == bi.getLivros()[x].getNome()){

					if (bi.getLivros()[x].VerificarClassificacao(bi.getUsuarioLogado().getIdade()) == false){
					return "O Usuario não possui idade para alugar este livro";
					}

					for(int y=0; y < livrosUsuario.Length; y++){ 
						numLivros += 1;

						if(numLivros > 3){
							return "O Usuario pode possuir no maximo 3 livros";
						}

						if(livrosUsuario[y] == null){
							livrosUsuario[y] = bi.getLivros()[x];
							bi.getLivros()[x] = null;
							return "-> Livro Alugado";
						}
					}
				}				
			}			
		}
		return "Livro não adicionado";
	}
	
	public void MostrarLivrosUsuario(){
		for(int x=0;x<livrosUsuario.Length;x++){
			if(livrosUsuario[x] != null){
				Console.WriteLine(livrosUsuario[x].getNome());
			}
		}
	}

	public string DevolverLivro(string nomeLivro,Biblioteca bi){
		for(int x=0;x<livrosUsuario.Length;x++){
			if(livrosUsuario[x] != null){
				if(nomeLivro == livrosUsuario[x].getNome()){
					for(int y=0;y<bi.getLivros().Length;y++){
						if(bi.getLivros()[y] == null){
							bi.getLivros()[y] = livrosUsuario[x];
							livrosUsuario[x] = null;
							return "Livro devolvido a Biblioteca";
						}
					}
				}
			}
		}
		return "Livro não devolvido";
	}
}