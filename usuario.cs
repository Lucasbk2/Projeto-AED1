using System;

class Usuario{

	//Declaração dos Metódos
	private string nome;
	private int idade;
	private string senha;
	private bool logado;
	private string cpf;
	private Livro[] livrosUsuario = new Livro [3];

	//Construtores
	public Usuario(string n, int i, string c){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.logado = false;
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
		logado = b;
	}
	//Métodos Funcionais


	}
