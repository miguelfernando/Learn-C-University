import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Aluno } from './aluno';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};


@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  url = 'http://localhost:58987/api/alunos';  
  constructor(private http: HttpClient) { }
  getAllAluno(): Observable<Aluno[]> {  
    return this.http.get<Aluno[]>(this.url + '/');  
  }  
  getAlunoById(alunoid: string): Observable<Aluno> {  
    const apiurl = `${this.url}/${alunoid}`;
    return this.http.get<Aluno>(apiurl);  
  }  
  createAluno(aluno: Aluno): Observable<Aluno> {  
    return this.http.post<Aluno>(this.url + '/incluir', aluno, httpOptions);  
  }  
  updateAluno(alunoid: string, aluno: Aluno): Observable<Aluno> {  
    const apiurl = this.url+ '/alterar?id=' + alunoid ;
    return this.http.put<Aluno>(apiurl,aluno, httpOptions);  
  }  
  deleteAlunoById(alunoid: string): Observable<number> {  
    return this.http.delete<number>(this.url + '/excluir?id=' + alunoid,httpOptions);  
  }
}
