import decode from "jwt-decode";

export class AuthService {
  constructor() {
    this.apiAddr = "https://eventrapi.azurewebsites.net/api";
    this.accessTokenName = "access_token";
    this.refreshTokenName = "refresh_token";
  }

  fetch = (url, options) => {
    const headers = {
      "Content-Type": "application/json"
    };
    if (this.loggedIn()) {
      headers["Authorization"] =
        "Bearer " + this.getToken(this.accessTokenName);
    }
    return fetch(url, { headers, ...options }).then(this._checkStatus);
  };

  _checkStatus = response => {
    console.log(response);
    if (response.status >= 200 && response.status < 300) {
      return response;
    } else {
      const error = new Error(response.statusText);
      error.response = response;
      throw error;
    }
  };

  loggedIn = () => {
    const token = this.getToken(this.accessTokenName);
    return !!token && this.isTokenExpired(token);
  };

  loggedInWithRefresh = () => {
    let token = this.getToken(this.accessTokenName);
    if (!!token && this.isTokenExpired(token)) this.refresh();

    token = this.getToken(this.accessTokenName);
    !!token && this.isTokenExpired(token);
  };

  isTokenExpired = token => {
    try {
      const decoded = decode(token);
      if (decoded.exp < Date.now() / 1000) return true;
      else return false;
    } catch (err) {
      console.log("Auth.isTokenExpired err");
      return false;
    }
  };
  login = async (nickname, password) => {
    const res = await fetch(`${this.apiAddr}/account/login`, {
      method: "POST",
      body: JSON.stringify({ nickname, password })
    });
    const resToken = await res.json();
    this.setToken(resToken.token, this.accessTokenName);
    this.setToken(resToken.refreshToken, this.refreshTokenName);
    return Promise.resolve(resToken);
  };

  logout = async () => {
    try {
      await this.fetch(`${this.apiAddr}/token/revoke`, {
        method: "POST"
      });
      localStorage.removeItem(this.accessTokenName);
      localStorage.removeItem(this.refreshTokenName);
    } catch (e) {
      localStorage.removeItem(this.accessTokenName);
      localStorage.removeItem(this.refreshTokenName);
    }
  };

  register = async (nickname, password, firstName, lastName, email) => {
    console.log(
      JSON.stringify({ nickname, password, firstName, lastName, email })
    );
    const res = await this.fetch(`${this.apiAddr}/account/signup`, {
      method: "POST",
      body: JSON.stringify({ nickname, password, firstName, lastName, email })
    });
    return await Promise.resolve(res);
  };

  setToken = (id, name) => localStorage.setItem(name, id);
  getToken = name => localStorage.getItem(name);

  refresh = async () => {
    const accessToken = this.getToken(this.accessTokenName);
    const refreshToken = this.getToken(this.refreshTokenName);
    const body = JSON.stringify({
      accessToken,
      refreshToken
    });

    const res = await this.fetch(`${this.apiAddr}/token/refresh`, {
      method: "POST",
      body: body
    });
    const resToken = await res.json();
    this.setToken(resToken.token, this.accessTokenName);
    this.setToken(resToken.refreshToken, this.refreshTokenName);
  };
}
export default AuthService;
