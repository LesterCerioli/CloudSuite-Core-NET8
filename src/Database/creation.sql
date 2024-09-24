CREATE DATABASE cloudsuite_core_db;

CREATE TABLE IF NOT EXISTS addresses(
    id SERIAL PRIMARY KEY,
    contact_name VARCHAR(50),
    address_line VARCHAR(450),
    cityId INT,
    districtId INT,
    CONSTRAINT FK_Address_City FOREIGN KEY (cityId) REFERENCES cities(id) ON DELETE RESTRICT,
    CONSTRAINT FK_Address_District FOREIGN KEY (districtId) REFERENCES districts(id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS cities(
    id SERIAL PRIMARY KEY,
    city_name VARCHAR(50) NOT NULL,
    stateId INT,
    CONSTRAINT FK_City_State FOREIGN KEY (stateId) REFERENCES states(id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS companies(
    id SERIAL PRIMARY KEY,
    cnpj_number VARCHAR(11) NOT NULL,
    fantasy_name VARCHAR(100) NOT NULL,
    register_name VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS countries(
    id SERIAL PRIMARY KEY,
    country_name VARCHAR(450) NOT NULL,
    code VARCHAR(450) NOT NULL,
    is_billing_enabled BIT,
    is_shipping_enabled BIT,
    is_city_enabled BIT,
    is_zip_code_enabled BIT,
    is_district_enabled BIT,
    stateId INT,
    CONSTRAINT FK_Country_State FOREIGN KEY (stateid) REFERENCES states(id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS districts (
    id SERIAL PRIMARY KEY,
    "name" VARCHAR(450) NOT NULL,
    "type" VARCHAR(20) NOT NULL,
    "location" VARCHAR(100) NOT NULL,
    cityId INT,
    CONSTRAINT FK_District_City FOREIGN KEY (cityId) REFERENCES cities(id) ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS medias (
    id SERIAL PRIMARY KEY,
    caption VARCHAR(450) NOT NULL,
    file_size INT NOT NULL,
    file_name VARCHAR(50) NOT NULL,
    media_type INT NOT NULL
);

CREATE TABLE IF NOT EXISTS states(
    id SERIAL PRIMARY KEY,
    state_name VARCHAR(100) NOT NULL,
    uf VARCHAR(2) NOT NULL,
    countryId INT,
    CONSTRAINT FK_State_Country FOREIGN KEY (countryId) REFERENCES countries(id) ON DELETE RESTRICT
);
