<?php include_once('db.php');


//check la connection 

//si il y a une erreur de connexion
if(mysqli_connect_errno()){

    echo "1: connection échoué";
    exit();
}
//variable d'enregistrement 


$id = $_POST["epaule"];
$epaule = $_POST["epaule"];
$poitrine = $_POST["poitrine"];
$manche = $_POST["manche"];
$totaille = $_POST["totaille"];
$taille = $_POST["taille"];


//check si le mail existe 

$sqlRg = "SELECT * from mensuration where id_mensuration  = '". $epaule. "'; ";

$queryRg = mysqli_query($con, $sqlRg) or die("echec de la requête");


    
// $insertuser = "INSERT INTO mensuration ( taille, epaule, tour_de_taille, poitrine, manche) values('".$taille."','".$epaule."','".$totaille."','".$poitrine."','".$manche."');";

// mysqli_query($con,$insertuser) or die("un problème est survenue");

$maninfo2 = "UPDATE mensuration SET epaule = '$epaule', poitrine='$poitrine', manche = '$manche', tour_de_taille = '$totaille', taille = '$taille'  WHERE epaule ='$epaule'";

mysqli_query($con,$maninfo2) or die("un problème est survenue");
    // infos enregistré




//echo "informations enregistrés";
echo("0");


//enregister un nouvel utilisateur


// ---- enregistrement du nouvel utilisateur

// $maninfo2 = "UPDATE mensuration SET epaule = '$epaule', poitrine='$poitrine', manche = '$manche', tour_de_taille = '$totaille', taille = '$taille' WHERE id_mensuration ='$id'";

// mysqli_query($con,$maninfo2) or die("un problème est survenue");
//     // infos enregistré
   