
ALTER TABLE dbo.BeslemeNoktalari
ADD
    NoktaAdi NVARCHAR(100) NULL,
    Enlem FLOAT NULL,
    Boylam FLOAT NULL,
    Aciklama NVARCHAR(500) NULL,
    Aktif BIT NOT NULL
        CONSTRAINT DF_BeslemeNoktalari_Aktif
        DEFAULT (1);
