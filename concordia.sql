-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2023 at 08:30 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `concordia`
--

-- --------------------------------------------------------

--
-- Table structure for table `add_employee`
--

CREATE TABLE `add_employee` (
  `id` int(11) NOT NULL,
  `fname` varchar(120) NOT NULL,
  `lname` varchar(120) NOT NULL,
  `date_timein` datetime(6) NOT NULL,
  `age` varchar(50) NOT NULL,
  `position` varchar(90) NOT NULL,
  `s_years` varchar(80) NOT NULL,
  `date_timeout` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `add_employee`
--

INSERT INTO `add_employee` (`id`, `fname`, `lname`, `date_timein`, `age`, `position`, `s_years`, `date_timeout`) VALUES
(13, 'Aaron', 'De guzman', '0000-00-00 00:00:00.000000', '31 and above', 'SK Chairman', 'New employee', '0000-00-00 00:00:00.000000'),
(14, 'Julius', 'Tindugan', '2023-12-11 20:59:33.000000', '15-20 years old', 'SK Councilor', 'New employee', '2023-12-11 20:58:27.000000'),
(15, 'Kristine Merylle', 'Lalong - Isip', '0000-00-00 00:00:00.000000', '15-20 years old', 'SK Councilor', 'New employee', '0000-00-00 00:00:00.000000'),
(16, 'Jhun Micko', 'Sanidad', '0000-00-00 00:00:00.000000', '15-20 years old', 'Barangay Councilor', '1-5 years', '0000-00-00 00:00:00.000000'),
(17, 'eaf', 'fes', '0000-00-00 00:00:00.000000', '15-20 years old', 'SK Chairman', '1-5 years', '0000-00-00 00:00:00.000000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `add_employee`
--
ALTER TABLE `add_employee`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `add_employee`
--
ALTER TABLE `add_employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
