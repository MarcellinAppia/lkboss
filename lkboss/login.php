<?php include_once('db.php');

//check la connection 

//si il y a une erreur de connexion
if(mysqli_connect_errno()){

    echo "1: connection échoué";
    exit();
}
//variable d'enregistrement 
//$nom = $_POST["nom"];
// $prenom = $_POST["prenom"];
 $email = $_POST["email"];
// $numero = $_POST["numero"];
$pwd1 = $_POST["pwd1"];
// $ville = $_POST["ville"];


//check si le mail existe 

$sqlRg = "SELECT email, nom, prenom,numero, hash, salt, ville from register where email = '". $email. "'; ";

$queryRg = mysqli_query($con, $sqlRg) or die("echec de la requête");

if(mysqli_num_rows($queryRg)!=1){

    echo "créez un compte svp";// 5; le nom existe deja dans la bd 
    exit();
}


//on recupere les infos
$result = mysqli_fetch_assoc($queryRg);

//mot de passe
$salt = $result["salt"];
$hash = $result["hash"];


$loginpwd = crypt($pwd1, $salt);
if($hash!=$loginpwd){

    echo "erreur de mot de passe"; //6; 
    exit();
}

$rnom = $result["nom"];
$rPnom = $result["prenom"];
$rville = $result["ville"];
$numb = $result["numero"];


    echo "0\t".$rnom."\t".$rPnom."\t".$rville."\t".$numb."\t".$hash;
  







