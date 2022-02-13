import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { catchError, map, retry } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private APIUrl = "http://localhost:3001/api/Employees";


  constructor(private http: HttpClient) { }

  GetAllEmployees(isActive: boolean): Observable<APIResult> {
    return this.http.get<APIResult>(this.APIUrl + '?IsActive=' + isActive).pipe(retry(1), catchError(this.handleError));
  }

  // Error handling 
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }


}

export interface APIResult {
  isSuccess: boolean;
  description: string;
  data: object;
}
