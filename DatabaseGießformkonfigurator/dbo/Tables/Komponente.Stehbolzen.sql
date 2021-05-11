CREATE TABLE [dbo].[Komponente.Stehbolzen] (
    [SAP-Nr.]              INT             NOT NULL,
    [Hoehe]                DECIMAL (10, 2) NOT NULL,
    [Durchmesser]          DECIMAL (10, 2) NOT NULL,
    [Gießhoehe_Max]        DECIMAL (10, 2) NOT NULL,
    [mit_Gewinde]          BIT             NOT NULL,
    [mit_Steckbolzen]      BIT             NOT NULL,
    [Hoehe_Fuehrung]       DECIMAL (10, 2) NOT NULL,
    [Durchmesser_Fuehrung] DECIMAL (10, 2) NOT NULL,
    [Gewinde]              DECIMAL (10, 2) NOT NULL
);

