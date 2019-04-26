-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 26, 2019 at 03:56 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bc`
--

--
-- Dumping data for table `ad`
--

INSERT INTO `ad` (`adID`, `targetURL`, `title`, `longTitle`, `description`, `companyName`, `nOfViews`, `adGroupID`, `webPageID`, `imageID`) VALUES
(6, 'testurl1.cz', 'Titulek1', 'Dlouhý Titulek1', 'A tady je popis1', 'Jewa', NULL, 5, 1, NULL),
(7, 'testurl5.cz', 'Titulek2', 'Dlouhý Titulek2', 'A tady je popis2', 'Jewa1', NULL, 6, 1, NULL),
(8, 'testurl5.cz', 'Titulek3', 'Dlouhý Titulek3', 'A tady je popis3', 'Jewa2', NULL, 6, 2, NULL),
(9, 'testurl7.cz', 'Titulek4', 'Dlouhý Titulek4', 'A tady je popis4', 'Avantgarde', NULL, 7, 3, NULL),
(10, 'testurl7.cz', 'Titulek5', 'Dlouhý Titulek5', 'A tady je popis5', 'Avantgarde1', NULL, 7, 3, NULL),
(11, 'testurl7.cz', 'Titulek6', 'Dlouhý Titulek6', 'A tady je popis6', 'Avantgarde2', NULL, 7, 3, NULL);

--
-- Dumping data for table `adcampaign`
--

INSERT INTO `adcampaign` (`campaignID`, `name`, `type`, `status`, `budget`, `costPer`, `start`, `ending`, `companyID`) VALUES
(5, 'Test1', 'Obsahová', 1, '200.00', '2.00', '2019-04-24 00:00:00', NULL, 12345677),
(6, 'Test2', 'Obsahová', 0, '2000.00', '13.00', '2019-05-29 00:00:00', '0000-00-00 00:00:00', 12345677);

--
-- Dumping data for table `adgroup`
--

INSERT INTO `adgroup` (`adGroupID`, `adGroupName`, `adGroupStatus`, `adGroupBudget`, `maxCostPer`, `requiredViews`, `campaignID`) VALUES
(5, 'Test11', 1, '140.00', '5.00', 10000, 5),
(6, 'Test12', 0, '100.00', NULL, 3000, 5),
(7, 'Test21', 1, NULL, '20.00', 43000, 6);

--
-- Dumping data for table `audience`
--

INSERT INTO `audience` (`audienceID`, `name`, `InterestID`, `categoryID`) VALUES
(1, 'Zájem o elektroniku', 1, NULL),
(2, 'Telefony', NULL, 1),
(3, 'Zájem o elektroniku a mí?ové sporty', 1, 4),
(4, 'Automobiloví nadšenci', 2, NULL),
(5, 'Zájem o sporty', 4, NULL),
(6, 'Zájem o elektroniku', 1, NULL),
(7, 'Telefony', NULL, 1),
(8, 'Zájem o elektroniku a mí?ové sporty', 1, 4),
(9, 'Automobiloví nadšenci', 2, NULL),
(10, 'Zájem o sporty', 4, NULL);

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`categoryID`, `categoryName`) VALUES
(1, 'Telefony'),
(2, 'Cyklistika'),
(3, 'Hobby'),
(4, 'Mí?ové sporty'),
(5, 'Po?íta?e'),
(6, 'Telefony'),
(7, 'Cyklistika'),
(8, 'Hobby'),
(9, 'Mí?ové sporty'),
(10, 'Po?íta?e');

--
-- Dumping data for table `company`
--

INSERT INTO `company` (`companyID`, `companyName`, `VIP`) VALUES
(12345677, 'Avantgarde', b'0'),
(12345678, 'Jewa', b'0'),
(12345688, 'Alza', b'1');

--
-- Dumping data for table `interest`
--

INSERT INTO `interest` (`interestID`, `interestName`, `description`) VALUES
(1, 'Elektronika', NULL),
(2, 'Automobily', NULL),
(3, 'D?m a zahrada', NULL),
(4, 'Sport', NULL),
(5, 'Elektronika', NULL),
(6, 'Automobily', NULL),
(7, 'D?m a zahrada', NULL),
(8, 'Sport', NULL);

--
-- Dumping data for table `visitor`
--

INSERT INTO `visitor` (`visitorID`, `name`, `location`) VALUES
(1, NULL, NULL),
(2, NULL, NULL),
(3, NULL, NULL),
(4, NULL, NULL),
(5, NULL, NULL),
(6, NULL, NULL),
(7, NULL, NULL),
(8, NULL, NULL),
(9, NULL, NULL),
(10, NULL, NULL),
(11, NULL, NULL),
(12, NULL, NULL),
(13, NULL, NULL),
(14, NULL, NULL),
(15, NULL, NULL),
(16, NULL, NULL),
(17, NULL, NULL),
(18, NULL, NULL),
(19, NULL, NULL),
(20, NULL, NULL);

--
-- Dumping data for table `webpage`
--

INSERT INTO `webpage` (`webPageID`, `URL`, `product`, `categoryID`) VALUES
(1, 'testurl1.cz', NULL, 1),
(2, 'testurl2.cz', NULL, 1),
(3, 'testurl2.cz', NULL, 2),
(4, 'testurl3.cz', NULL, 3),
(5, 'testurl4.cz', NULL, 4),
(6, 'testurl5.cz', NULL, 5),
(7, 'testurl6.cz', NULL, 5),
(8, 'testurl7.cz', NULL, 2),
(9, 'testurl1.cz', NULL, 1),
(10, 'testurl2.cz', NULL, 1),
(11, 'testurl2.cz', NULL, 2),
(12, 'testurl3.cz', NULL, 3),
(13, 'testurl4.cz', NULL, 4),
(14, 'testurl5.cz', NULL, 5),
(15, 'testurl6.cz', NULL, 5),
(16, 'testurl7.cz', NULL, 2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
