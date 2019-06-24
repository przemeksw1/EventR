import decode from "jwt-decode";

export class AuthService {
  constructor() {
    this.apiAddr = "https://eventrapi.azurewebsites.net/api";
    this.corsAddr = "https://cors-anywhere.herokuapp.com/";
    this.accessTokenName = "access_token";
    this.refreshTokenName = "refresh_token";
  }

  fetch = (url, options) => {
    const headers = {
      "Content-Type": "application/json",
      Origin: "localhost:3000"
    };
    if (this.loggedIn()) {
      headers["Authorization"] =
        "Bearer " + this.getToken(this.accessTokenName);
    }
    return fetch(url, { headers, ...options }).then(this._checkStatus);
  };

  _checkStatus = response => {
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
      console.log(decoded.exp, Date.now() / 1000);
      if (decoded.exp > Date.now() / 1000) return true;
      else return false;
    } catch (err) {
      console.log("Auth.isTokenExpired err");
      return false;
    }
  };
  login = (email, password) => {
    this.fetch(`${this.corsAddr + this.apiAddr}/account/login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password })
    })
      .then(res => {
        return res.json();
      })
      .then(res => {
        this.setToken(res.token, this.accessTokenName);
        this.setToken(res.refreshToken, this.refreshTokenName);
        Promise.resolve(res);
        window.location.reload();
      });
  };

  logout = async () => {
    try {
      await this.fetch(`${this.corsAddr + this.apiAddr}/token/revoke`, {
        method: "POST"
      });
      localStorage.removeItem(this.accessTokenName);
      localStorage.removeItem(this.refreshTokenName);
    } catch (e) {
      localStorage.removeItem(this.accessTokenName);
      localStorage.removeItem(this.refreshTokenName);
    }
    window.location.reload();
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
