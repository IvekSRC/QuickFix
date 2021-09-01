function myFunction() {
    var pom = localStorage.getItem("key");
    if (pom == "light")
    {
        // Light mode
        document.querySelector(".headerIndex").style.backgroundColor = "darkgray";
        document.querySelector(".layoutBody").style.backgroundColor = "darkkhaki";
        if(document.querySelector(".indexGlavniDiv") != null)
        {
            document.querySelector(".indexGlavniDiv").style.backgroundColor = "darkkhaki";
        }
        if(document.querySelector(".divTabelcina") != null)
        {
            document.querySelector(".divTabelcina").style.backgroundColor = "lightcyan";
        }
        if(document.querySelector(".filterPretrage") != null)
        {
            document.querySelector(".filterPretrage").style.backgroundColor = "lightsteelblue";
        }
        if(document.querySelector(".divDostupnihServisa") != null)
        {
            document.querySelector(".divDostupnihServisa").style.backgroundColor = "khaki";
        }
        if(document.querySelector(".divBezServisa") != null)
        {
            document.querySelector(".divBezServisa").style.backgroundColor = "linen";
        }
        if(document.querySelector(".osnovniDiv") != null)
        {
            document.querySelector(".osnovniDiv").style.backgroundColor = "cornflowerblue";
        }
        if(document.querySelector(".unutarLevog") != null)
        {
            document.querySelector(".unutarLevog").style.backgroundColor = "blanchedalmond";
        }
        if(document.querySelector(".tataa") != null)
        {
            document.querySelector(".tataa").style.backgroundColor = "lightsteelblue";
        }
        if(document.querySelector(".noviTataa") != null)
        {
            document.querySelector(".noviTataa").style.backgroundColor = "gainsboro";
        }
        if(document.querySelector(".tata3") != null)
        {
            document.querySelector(".tata3").style.backgroundColor = "gainsboro";
        }
        if(document.querySelector(".osnovneInfOMajstoru") != null)
        {
            document.querySelector(".osnovneInfOMajstoru").style.backgroundColor = "gainsboro";
        }
        if(document.querySelector(".tabelaInfMajj") != null)
        {
            document.querySelector(".tabelaInfMajj").style.backgroundColor = "lemonchiffon";
        }
        if(document.querySelector(".zaUslugu") != null)
        {
            document.querySelector(".zaUslugu").style.backgroundColor = "lightgray";
        }
        if(document.querySelector(".tabelaInfMajjj") != null)
        {
            document.querySelector(".tabelaInfMajjj").style.backgroundColor = "lavender";
        }
        if(document.querySelector(".baki") != null)
        {
            document.querySelector(".baki").style.backgroundColor = "blanchedalmond";
        }
        if(document.querySelector(".haki") != null)
        {
            document.querySelector(".haki").style.backgroundColor = "linen";
        }
        if(document.querySelector(".tabelaInfMajje") != null)
        {
            document.querySelector(".tabelaInfMajje").style.backgroundColor = "lemonchiffon";
        }
        if(document.querySelector(".komentarskiDiv") != null)
        {
            document.querySelector(".komentarskiDiv").style.backgroundColor = "mintcream";
        }
        if(document.querySelectorAll(".divKomentara") != null)
        {
            let pom = document.querySelectorAll(".divKomentara");
            pom.forEach(element => {
                element.style.backgroundColor = "lemonchiffon";
            });
        }
        if(document.querySelectorAll(".sadrzajKomentara") != null)
        {
            let pom = document.querySelectorAll(".sadrzajKomentara");
            pom.forEach(element => {
                element.style.backgroundColor = "palegoldenrod";
            });
        }
        if(document.querySelector(".element") != null)
        {
            document.querySelector(".element").style.backgroundColor = "seashell";
        }
        if(document.querySelector(".unosOsnovnihPod") != null)
        {
            document.querySelector(".unosOsnovnihPod").style.backgroundColor = "palegoldenrod";
        }
        if(document.querySelectorAll(".prviDiv") != null)
        {
            let pom = document.querySelectorAll(".prviDiv");
            pom.forEach(element => {
                element.style.backgroundColor = "peachpuff";
            });
        }
        if(document.querySelector(".div1") != null)
        {
            document.querySelector(".div1").style.backgroundColor = "skyblue";
        }
        if(document.querySelector(".pomm") != null)
        {
            document.querySelector(".pomm").style.backgroundColor = "cornsilk";
        }
        if(document.querySelector(".div4") != null)
        {
            document.querySelector(".div4").style.backgroundColor = "lightgray";
        }
        if(document.querySelector(".adminDiv") != null)
        {
            document.querySelector(".adminDiv").style.backgroundColor = "linen";
        }
        if(document.querySelector(".serviskiDiv") != null)
        {
            document.querySelector(".serviskiDiv").style.backgroundColor = "peachpuff";
        }
        if(document.querySelector(".vlasnickiDiv") != null)
        {
            document.querySelector(".vlasnickiDiv").style.backgroundColor = "honeydew";
        }
        if(document.querySelector(".divAdm") != null)
        {
            document.querySelector(".divAdm").style.backgroundColor = "palegoldenrod";
        }
        if(document.querySelector(".zahtevi") != null)
        {
            document.querySelector(".zahtevi").style.backgroundColor = "lightgrey";
        }

        console.log(pom);
        localStorage.setItem("key", "dark");

        document.querySelector(".slikaUredjaja").innerHTML = "";
        var img = document.createElement("img");
        img.className = "majstorSlika";
        img.src = "Slike/majstorSlikaDark.png";
        document.querySelector(".slikaUredjaja").appendChild(img);
    }
    else
    {
        // Dark mode
        document.querySelector(".onoffswitch-checkbox").checked = true;

        document.querySelector(".headerIndex").style.backgroundColor = "white";
        document.querySelector(".layoutBody").style.backgroundColor = "white";
        if(document.querySelector(".indexGlavniDiv") != null)
        {
            document.querySelector(".indexGlavniDiv").style.backgroundColor = "white";
        }
        if(document.querySelector(".divTabelcina") != null)
        {
            document.querySelector(".divTabelcina").style.backgroundColor = "white";
        }
        if(document.querySelector(".filterPretrage") != null)
        {
            document.querySelector(".filterPretrage").style.backgroundColor = "white";
        }
        if(document.querySelector(".divDostupnihServisa") != null)
        {
            document.querySelector(".divDostupnihServisa").style.backgroundColor = "white";
        }
        if(document.querySelector(".divBezServisa") != null)
        {
            document.querySelector(".divBezServisa").style.backgroundColor = "white";
        }
        if(document.querySelector(".osnovniDiv") != null)
        {
            document.querySelector(".osnovniDiv").style.backgroundColor = "white";
        }
        if(document.querySelector(".unutarLevog") != null)
        {
            document.querySelector(".unutarLevog").style.backgroundColor = "white";
        }
        if(document.querySelector(".tataa") != null)
        {
            document.querySelector(".tataa").style.backgroundColor = "white";
        }
        if(document.querySelector(".noviTataa") != null)
        {
            document.querySelector(".noviTataa").style.backgroundColor = "white";
        }
        if(document.querySelector(".tata3") != null)
        {
            document.querySelector(".tata3").style.backgroundColor = "white";
        }
        if(document.querySelector(".osnovneInfOMajstoru") != null)
        {
            document.querySelector(".osnovneInfOMajstoru").style.backgroundColor = "white";
        }
        if(document.querySelector(".tabelaInfMajj") != null)
        {
            document.querySelector(".tabelaInfMajj").style.backgroundColor = "white";
        }
        if(document.querySelector(".zaUslugu") != null)
        {
            document.querySelector(".zaUslugu").style.backgroundColor = "white";
        }
        if(document.querySelector(".tabelaInfMajjj") != null)
        {
            document.querySelector(".tabelaInfMajjj").style.backgroundColor = "white";
        }
        if(document.querySelector(".baki") != null)
        {
            document.querySelector(".baki").style.backgroundColor = "white";
        }
        if(document.querySelector(".haki") != null)
        {
            document.querySelector(".haki").style.backgroundColor = "white";
        }
        if(document.querySelector(".tabelaInfMajje") != null)
        {
            document.querySelector(".tabelaInfMajje").style.backgroundColor = "white";
        }
        if(document.querySelector(".komentarskiDiv") != null)
        {
            document.querySelector(".komentarskiDiv").style.backgroundColor = "white";
        }
        if(document.querySelectorAll(".divKomentara") != null)
        {
            let pom = document.querySelectorAll(".divKomentara");
            pom.forEach(element => {
                element.style.backgroundColor = "white";
            });
        }
        if(document.querySelectorAll(".sadrzajKomentara") != null)
        {
            let pom = document.querySelectorAll(".sadrzajKomentara");
            pom.forEach(element => {
                element.style.backgroundColor = "white";
            });
        }
        if(document.querySelector(".element") != null)
        {
            document.querySelector(".element").style.backgroundColor = "white";
        }
        if(document.querySelector(".unosOsnovnihPod") != null)
        {
            document.querySelector(".unosOsnovnihPod").style.backgroundColor = "white";
        }
        if(document.querySelectorAll(".prviDiv") != null)
        {
            let pom = document.querySelectorAll(".prviDiv");
            pom.forEach(element => {
                element.style.backgroundColor = "white";
            });
        }
        if(document.querySelector(".div1") != null)
        {
            document.querySelector(".div1").style.backgroundColor = "white";
        }
        if(document.querySelector(".pomm") != null)
        {
            document.querySelector(".pomm").style.backgroundColor = "white";
        }
        if(document.querySelector(".div4") != null)
        {
            document.querySelector(".div4").style.backgroundColor = "white";
        }
        if(document.querySelector(".adminDiv") != null)
        {
            document.querySelector(".adminDiv").style.backgroundColor = "white";
        }
        if(document.querySelector(".serviskiDiv") != null)
        {
            document.querySelector(".serviskiDiv").style.backgroundColor = "white";
        }
        if(document.querySelector(".vlasnickiDiv") != null)
        {
            document.querySelector(".vlasnickiDiv").style.backgroundColor = "white";
        }
        if(document.querySelector(".divAdm") != null)
        {
            document.querySelector(".divAdm").style.backgroundColor = "white";
        }
        if(document.querySelector(".zahtevi") != null)
        {
            document.querySelector(".zahtevi").style.backgroundColor = "white";
        }
        
        console.log(pom);
        localStorage.setItem("key", "light");

        document.querySelector(".slikaUredjaja").innerHTML = "";
        var img = document.createElement("img");
        img.className = "majstorSlika";
        img.src = "Slike/majstorSlikaBeli.png";
        document.querySelector(".slikaUredjaja").appendChild(img);
    }
}

function IzmeniNazivServisa(){
    
    let servis1 = document.getElementById('nazivServisa').value;

    if(servis1.length<3)
    {
        alert("Novi naziv servisa mora da sadrzi barem 3 karaktera !");
    }
}

function IzmeniLokacijuServisa(){
    let servis2 = document.getElementById('lokacijaServisa').value;

    if(servis2.length<3) {
        alert("Nova lokacija servisa mora da sadrzi barem 3 karaktera !");
    }
}

function IzmeniImeVlasnika() {
    let vlasnik1= document.getElementById('imeVlasnika').value;
    if(vlasnik1.length < 2) {
        alert("Novo ime vlasnika mora da sadrzi barem 2 karaktera!");
    }
}

function IzmeniPrezimeVlasnika() {
    let vlasnik2= document.getElementById('prezimeVlasnika').value;
    if(vlasnik2.length < 2) {
        alert("Novo prezime vlasnika mora da sadrzi barem 2 karaktera!");
    }
}

function IzmeniBrGodVlasnika() {
    let vlasnik3= document.getElementById('godineVlasnika').value;
    if(vlasnik3 < 18){
        alert("Mora da bude punoletan !");
    }
}

function IzmeniIskustvoVlasnika() {
    let vlasnik3= document.getElementById('godineVlasnika').value;
    
}

function IzmeniPodatkeOAdministratoru() {
    let administrator= document.getElementById('myInput').value;
    if(administrator.length < 3) {
        alert("Lozinka administratora mora da sadrzi barem 3 karaktera!");
    }
}