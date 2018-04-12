// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  firebase: {
    apiKey: "AIzaSyCoHyjHVYt4boAJhCQ8JMKrciK_osZXKm4",
    authDomain: "srh-authentication.firebaseapp.com",
    databaseURL: "https://srh-authentication.firebaseio.com",
    projectId: "srh-authentication",
    storageBucket: "",
    messagingSenderId: "1044054211717"
  }
};
