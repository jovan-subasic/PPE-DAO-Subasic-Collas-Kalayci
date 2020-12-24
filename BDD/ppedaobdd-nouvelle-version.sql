#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: partenaires
#------------------------------------------------------------

CREATE TABLE partenaires(
        id  Int  Auto_increment  NOT NULL ,
        nom Varchar (50) NOT NULL
	,CONSTRAINT partenaires_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: stands
#------------------------------------------------------------

CREATE TABLE stands(
        id             Int  Auto_increment  NOT NULL ,
        idAllee        Int NOT NULL ,
        idOrdre        Int NOT NULL ,
        equipement     Varchar (50) NOT NULL ,
        montantFacture Int NOT NULL ,
        prix           Int NOT NULL ,
        nom            Varchar (50) NOT NULL ,
        id_partenaires Int NOT NULL
	,CONSTRAINT stands_PK PRIMARY KEY (id)

	,CONSTRAINT stands_partenaires_FK FOREIGN KEY (id_partenaires) REFERENCES partenaires(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: participants
#------------------------------------------------------------

CREATE TABLE participants(
        id                   Int  Auto_increment  NOT NULL ,
        prenom               Varchar (50) NOT NULL ,
        adresse              Varchar (50) NOT NULL ,
        portable             Varchar (50) NOT NULL ,
        type                 Varchar (50) NOT NULL ,
        nombre_Participation Int NOT NULL
	,CONSTRAINT participants_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: atelier
#------------------------------------------------------------

CREATE TABLE atelier(
        id              Int  Auto_increment  NOT NULL ,
        nom             Varchar (50) NOT NULL ,
        capacite        Int NOT NULL ,
        id_participants Int NOT NULL
	,CONSTRAINT atelier_PK PRIMARY KEY (id)

	,CONSTRAINT atelier_participants_FK FOREIGN KEY (id_participants) REFERENCES participants(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: themes
#------------------------------------------------------------

CREATE TABLE themes(
        id         Int  Auto_increment  NOT NULL ,
        nom        Varchar (50) NOT NULL ,
        id_atelier Int NOT NULL
	,CONSTRAINT themes_PK PRIMARY KEY (id)

	,CONSTRAINT themes_atelier_FK FOREIGN KEY (id_atelier) REFERENCES atelier(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: equipements
#------------------------------------------------------------

CREATE TABLE equipements(
        id Int  Auto_increment  NOT NULL
	,CONSTRAINT equipements_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Date
#------------------------------------------------------------

CREATE TABLE Date(
        id         Int NOT NULL ,
        date_debut Datetime NOT NULL ,
        date_fin   Datetime NOT NULL
	,CONSTRAINT Date_PK PRIMARY KEY (id)

	,CONSTRAINT Date_atelier_FK FOREIGN KEY (id) REFERENCES atelier(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Intervention
#------------------------------------------------------------

CREATE TABLE Intervention(
        email Varchar (50) NOT NULL ,
        id    Int NOT NULL
	,CONSTRAINT Intervention_PK PRIMARY KEY (email)

	,CONSTRAINT Intervention_Date_FK FOREIGN KEY (id) REFERENCES Date(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: intervenir
#------------------------------------------------------------

CREATE TABLE intervenir(
        email Varchar (50) NOT NULL ,
        id    Int NOT NULL
	,CONSTRAINT intervenir_PK PRIMARY KEY (email,id)

	,CONSTRAINT intervenir_Intervention_FK FOREIGN KEY (email) REFERENCES Intervention(email)
	,CONSTRAINT intervenir_participants0_FK FOREIGN KEY (id) REFERENCES participants(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: participer
#------------------------------------------------------------

CREATE TABLE participer(
        id         Int NOT NULL ,
        id_atelier Int NOT NULL
	,CONSTRAINT participer_PK PRIMARY KEY (id,id_atelier)

	,CONSTRAINT participer_participants_FK FOREIGN KEY (id) REFERENCES participants(id)
	,CONSTRAINT participer_atelier0_FK FOREIGN KEY (id_atelier) REFERENCES atelier(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: posseder
#------------------------------------------------------------

CREATE TABLE posseder(
        id        Int NOT NULL ,
        id_stands Int NOT NULL
	,CONSTRAINT posseder_PK PRIMARY KEY (id,id_stands)

	,CONSTRAINT posseder_equipements_FK FOREIGN KEY (id) REFERENCES equipements(id)
	,CONSTRAINT posseder_stands0_FK FOREIGN KEY (id_stands) REFERENCES stands(id)
)ENGINE=InnoDB;

