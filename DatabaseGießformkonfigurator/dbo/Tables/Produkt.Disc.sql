CREATE TABLE [dbo].[Produkt.Disc] (
    [SAP-Nr.]          INT             NOT NULL,
    [Außendurchmesser] DECIMAL (10, 2) NOT NULL,
    [LK]               CHAR (4)        NOT NULL,
    [Hoehe]            DECIMAL (10, 2) NOT NULL,
    [Innendurchmesser] DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Produkt.Disc] PRIMARY KEY CLUSTERED ([SAP-Nr.] ASC)
);

