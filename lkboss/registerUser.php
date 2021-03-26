<?php include_once('db.php');


//check la connection 

//si il y a une erreur de connexion
if(mysqli_connect_errno()){

    echo "1: connection échoué";
    exit();
}
//variable d'enregistrement 
$nom = $_POST["nom"];
$prenom = $_POST["prenom"];
$email = $_POST["email"];
$numero = $_POST["numero"];
$pwd1 = $_POST["pwd1"];
$ville = $_POST["ville"];


//check si le mail existe 

$sqlRg = "SELECT nom from register where nom = '". $nom. "'; ";

$queryRg = mysqli_query($con, $sqlRg) or die("echec de la requête");

if(mysqli_num_rows($queryRg)>0){

    echo "3: vous êtes déjà enregistré";// le nom existe deja dans la bd 
    exit();
}

//enregister un nouvel utilisateur

//---securité hash du mot passe
$salt = "\$5\$rounds=5000\$". "somheashch".$nom."\$";

$hash = crypt($pwd1, $salt);

// ---- enregistrement du nouvel utilisateur

$insertuser = "INSERT INTO register( nom, prenom, email, numero, hash, salt, ville) values('".$nom."','".$prenom."','".$email."','".$numero."','".$hash."','".$salt."','".$ville."');";

mysqli_query($con,$insertuser) or die("un problème est survenue");

echo("0");