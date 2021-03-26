<?php include_once('db.php');


//check la connection 

//si il y a une erreur de connexion
if(mysqli_connect_errno()){

    echo "1: connection échoué";
    exit();
}
//variable d'enregistrement 
$nom = $_POST["nom"];
$pwd1 = $_POST["pwd1"];
//$prenom = $_POST["prenom"];
//$email = $_POST["email"];
//$numero = $_POST["numero"];

//$ville = $_POST["ville"];


//check si le mail existe 

$sqlRg = "SELECT nom from register where nom = '$nom'";

$queryRg = mysqli_query($con, $sqlRg) or die("echec de la requête");

if(mysqli_num_rows($queryRg)!=1){

    echo "3: vous êtes déjà enregistré";// le nom existe deja dans la bd 
    exit();
}else{
//enregister un nouvel utilisateur

//---securité hash du mot passe
$salt = "\$5\$rounds=5000\$". "somheashch".$nom."\$";

$hash = crypt($pwd1, $salt);

// ---- enregistrement du nouvel utilisateur

//$updateU = "UPDATE register set hash = ".$hash.", salt = ".$salt." WHERE nom ='".$nom."' ;";
//$up = "UPDATE register SET numero = '$numero' WHERE nom ='$nom'";
$up = "UPDATE register SET hash = '$hash', salt='$salt' WHERE nom ='$nom'";

mysqli_query($con,$up) or die("il y a une erreur");

echo "0";}
