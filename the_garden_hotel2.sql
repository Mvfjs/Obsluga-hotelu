-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sty 10, 2025 at 05:21 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `the garden hotel2`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `bookings`
--

CREATE TABLE `bookings` (
  `BookingID` int(11) NOT NULL,
  `GuestID` int(11) NOT NULL COMMENT 'ID goscia',
  `RoomID` int(11) NOT NULL COMMENT 'ID pokoju',
  `CheckINdate` date NOT NULL COMMENT 'Data zameldowania',
  `CheckOUTdate` date NOT NULL COMMENT 'Data wymeldowania',
  `TotalPrice` decimal(10,2) NOT NULL COMMENT 'Koszt rezerwacji',
  `ReservationCode` varchar(10) NOT NULL COMMENT 'Kod do logowania',
  `BookingStatus` enum('Potwierdzono','Anulowano','Oczekuje','') NOT NULL COMMENT 'Status rezerwacji'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookings`
--

INSERT INTO `bookings` (`BookingID`, `GuestID`, `RoomID`, `CheckINdate`, `CheckOUTdate`, `TotalPrice`, `ReservationCode`, `BookingStatus`) VALUES
(1000, 1, 1000, '2024-12-01', '2024-12-06', 200.00, 'BOOK001', 'Potwierdzono'),
(1001, 2, 1001, '2024-12-06', '2024-12-11', 300.00, 'BOOK002', 'Potwierdzono'),
(1002, 3, 1002, '2024-12-11', '2024-12-16', 400.00, 'BOOK003', 'Potwierdzono'),
(1003, 4, 1003, '2024-12-16', '2024-12-21', 250.00, 'BOOK004', 'Potwierdzono'),
(1004, 5, 1004, '2024-12-21', '2024-12-26', 350.00, 'BOOK005', 'Potwierdzono'),
(1005, 6, 1005, '2024-12-26', '2024-12-31', 150.00, 'BOOK006', 'Potwierdzono'),
(1006, 7, 1006, '2025-01-01', '2025-01-06', 500.00, 'BOOK007', 'Potwierdzono'),
(1007, 8, 1007, '2025-01-06', '2025-01-11', 600.00, 'BOOK008', 'Potwierdzono'),
(1008, 9, 1008, '2025-01-11', '2025-01-16', 700.00, 'BOOK009', 'Potwierdzono'),
(1009, 10, 1009, '2025-01-16', '2025-01-21', 800.00, 'BOOK010', 'Potwierdzono'),
(1016, 783, 1003, '2025-01-09', '2025-01-14', 300.00, 'e553d433', 'Potwierdzono'),
(1017, 784, 1000, '2025-01-09', '2025-01-14', 850.00, '4DA5A808', 'Potwierdzono'),
(1018, 785, 1005, '2025-01-09', '2025-01-26', 1275.00, 'BOOK011', 'Potwierdzono'),
(1019, 786, 1008, '2025-01-09', '2025-01-28', 1140.00, 'BOOK012', 'Potwierdzono'),
(1020, 787, 1000, '2025-01-14', '2025-01-22', 400.00, 'BOOK013', 'Potwierdzono'),
(1021, 788, 1000, '2025-01-22', '2025-01-29', 350.00, 'BOOK014', 'Potwierdzono'),
(1022, 789, 1002, '2025-03-01', '2025-03-08', 700.00, 'BOOK015', 'Potwierdzono'),
(1023, 790, 1002, '2025-01-09', '2025-01-24', 1500.00, 'BOOK016', 'Potwierdzono');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `guests`
--

CREATE TABLE `guests` (
  `GuestID` int(30) NOT NULL COMMENT 'Unikalne ID goscia	',
  `FirstName` varchar(60) NOT NULL COMMENT 'Imie goscia',
  `LastName` varchar(60) NOT NULL COMMENT 'Nazwisko goscia',
  `Email` varchar(120) NOT NULL COMMENT 'Adres e-mail',
  `PhoneNumber` varchar(20) NOT NULL COMMENT 'NumerTelefonu'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guests`
--

INSERT INTO `guests` (`GuestID`, `FirstName`, `LastName`, `Email`, `PhoneNumber`) VALUES
(1, 'Anna', 'Kowalska', 'anna.kowalska@gmail.com', '123456789'),
(2, 'Piotr', 'Nowicki', 'piotr.nowicki@gmail.com', '987654321'),
(3, 'Maria', 'Zielińska', 'maria.zielinska@gmail.com', '555888999'),
(4, 'Tomasz', 'Wiśniewski', 'tomasz.wisniewski@gmail.com', '444555666'),
(5, 'Katarzyna', 'Lewandowska', 'katarzyna.lewandowska@gmail.com', '777888111');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rooms`
--

CREATE TABLE `rooms` (
  `RoomID` int(11) NOT NULL,
  `RoomNumber` varchar(15) NOT NULL COMMENT 'Numer pokoju',
  `RoomType` enum('jednoosobowy','dwuosobowy','trzyosobowy',' rodzinny') NOT NULL COMMENT 'Rodzaj pokoju',
  `Price` decimal(10,2) NOT NULL COMMENT 'Cena za noc',
  `Status` enum('Wolny','Zajęty','Prace techniczne','') NOT NULL COMMENT 'Status pokoju'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`RoomID`, `RoomNumber`, `RoomType`, `Price`, `Status`) VALUES
(1000, '1112', 'dwuosobowy', 50.00, 'Zajęty'),
(1001, '1113', 'trzyosobowy', 75.00, 'Zajęty'),
(1002, '1114', '', 100.00, 'Prace techniczne'),
(1003, '1115', 'jednoosobowy', 30.00, 'Zajęty'),
(1004, '1116', 'dwuosobowy', 50.00, 'Zajęty'),
(1005, '1117', 'trzyosobowy', 75.00, 'Zajęty'),
(1006, '1118', '', 120.00, 'Zajęty'),
(1007, '1119', 'jednoosobowy', 30.00, 'Prace techniczne'),
(1008, '1120', 'dwuosobowy', 60.00, 'Zajęty'),
(1009, '1121', 'trzyosobowy', 100.00, 'Zajęty');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `serviceorders`
--

CREATE TABLE `serviceorders` (
  `ServiceOrderID` int(11) NOT NULL COMMENT 'unikalny id zamowienia',
  `BookingID` int(11) NOT NULL COMMENT 'ID rezerwacji',
  `ServiceID` int(11) NOT NULL COMMENT 'ID usulugi',
  `OrderDate` datetime NOT NULL COMMENT 'Data i czas zamowienia',
  `TotalPrice` decimal(10,2) NOT NULL COMMENT 'koszt zamowienia'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `serviceorders`
--

INSERT INTO `serviceorders` (`ServiceOrderID`, `BookingID`, `ServiceID`, `OrderDate`, `TotalPrice`) VALUES
(1, 1000, 1, '2024-12-01 12:00:00', 50.00),
(2, 1001, 2, '2024-12-06 14:00:00', 100.00),
(3, 1002, 3, '2024-12-11 15:00:00', 75.00),
(4, 1003, 4, '2024-12-16 16:00:00', 120.00),
(5, 1004, 5, '2024-12-21 18:00:00', 60.00),
(6, 1005, 6, '2024-12-26 10:00:00', 200.00),
(7, 1006, 7, '2025-01-01 11:00:00', 180.00),
(8, 1007, 8, '2025-01-06 13:00:00', 90.00),
(9, 1008, 9, '2025-01-11 09:00:00', 140.00),
(10, 1009, 10, '2025-01-16 17:00:00', 130.00);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `services`
--

CREATE TABLE `services` (
  `ServiceID` int(11) NOT NULL COMMENT 'Unikalny ID uslugi',
  `ServiceName` varchar(150) NOT NULL COMMENT 'Nazwa uslugi',
  `Description` text NOT NULL COMMENT 'opis uslugi',
  `PriceService` decimal(10,2) NOT NULL COMMENT 'Cena za usluge'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `services`
--

INSERT INTO `services` (`ServiceID`, `ServiceName`, `Description`, `PriceService`) VALUES
(1, 'posiłek do pokoju', 'Dostarczanie posiłków do pokoju', 50.00),
(2, 'sprzątanie', 'Codzienne sprzątanie pokoju', 20.00),
(3, 'wymiana ręczników', 'Wymiana ręczników na nowe', 10.00),
(4, 'pranie', 'Usługa prania odzieży', 30.00),
(5, 'prasowanie', 'Usługa prasowania odzieży', 25.00),
(6, 'dodatkowe łóżko', 'Dostarczenie dodatkowego łóżka do pokoju', 40.00),
(7, 'mini bar', 'Zaopatrzenie minibaru', 60.00),
(8, 'transfer na lotnisko', 'Transport z/na lotnisko', 100.00),
(9, 'budzenie', 'Usługa porannego budzenia', 5.00),
(10, 'dostęp do spa', 'Jednorazowy dostęp do strefy SPA', 120.00);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`BookingID`),
  ADD UNIQUE KEY `BookingID` (`BookingID`) USING BTREE,
  ADD KEY `GuestID` (`GuestID`),
  ADD KEY `RoomID` (`RoomID`);

--
-- Indeksy dla tabeli `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`GuestID`) USING BTREE,
  ADD UNIQUE KEY `GuestID` (`GuestID`) USING BTREE;

--
-- Indeksy dla tabeli `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`RoomID`) USING BTREE,
  ADD UNIQUE KEY `RoomNumber` (`RoomNumber`) USING BTREE,
  ADD UNIQUE KEY `RoomID` (`RoomID`) USING BTREE;

--
-- Indeksy dla tabeli `serviceorders`
--
ALTER TABLE `serviceorders`
  ADD PRIMARY KEY (`ServiceOrderID`),
  ADD UNIQUE KEY `ServiceOrderID` (`ServiceOrderID`) USING BTREE,
  ADD KEY `BookingID` (`BookingID`),
  ADD KEY `ServiceID` (`ServiceID`);

--
-- Indeksy dla tabeli `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`ServiceID`) USING BTREE,
  ADD UNIQUE KEY `ServiceID` (`ServiceID`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `BookingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1024;

--
-- AUTO_INCREMENT for table `guests`
--
ALTER TABLE `guests`
  MODIFY `GuestID` int(30) NOT NULL AUTO_INCREMENT COMMENT 'Unikalne ID goscia	', AUTO_INCREMENT=791;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `RoomID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1026;

--
-- AUTO_INCREMENT for table `serviceorders`
--
ALTER TABLE `serviceorders`
  MODIFY `ServiceOrderID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'unikalny id zamowienia', AUTO_INCREMENT=124;

--
-- AUTO_INCREMENT for table `services`
--
ALTER TABLE `services`
  MODIFY `ServiceID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unikalny ID uslugi', AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `serviceorders`
--
ALTER TABLE `serviceorders`
  ADD CONSTRAINT `fk_serviceorders_bookings` FOREIGN KEY (`BookingID`) REFERENCES `bookings` (`BookingID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
