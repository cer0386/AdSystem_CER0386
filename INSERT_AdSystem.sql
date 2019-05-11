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

INSERT INTO `CampaignType` (`campaignTypeID`, `type`) VALUES
(1, 'Obsahová');

INSERT INTO `company` (`companyID`, `companyName`, `VIP`) VALUES
(12345677, 'Avantgarde', b'0'),
(12345678, 'Jewa', b'0'),
(12345688, 'Alza', b'1');

INSERT INTO `adcampaign` (`campaignID`, `name`, `status`, `budget`, `costPer`, `start`, `ending`, `companyID`, campaignTypeID) VALUES
(1, 'Test1', 1, '200.00', '2.00', '2019-04-24 00:00:00', NULL, 12345677, 1),
(2, 'Test2', 0, '2000.00', '13.00', '2019-05-29 00:00:00', '2019-06-29', 12345677, 1);


INSERT INTO `adgroup` (`adGroupID`, `adGroupName`, `adGroupStatus`, `adGroupBudget`, `maxCostPer`, `requiredViews`, `campaignID`) VALUES
(1, 'Test11 Telefony', 1, '140.00', '5.00', 10000, 1),
(2, 'Test12 Telefony2', 0, '100.00', NULL, 3000, 1),
(3, 'Test21 Cyklistika', 1, NULL, '20.00', 43000, 2),
(4, 'Test21 Míčové sporty', 1, NULL, '20.00', 43000, 2);

INSERT INTO `category` (`categoryID`, `categoryName`) VALUES
(1, 'Telefony'),
(2, 'Cyklistika'),
(3, 'Hobby'),
(4, 'Míčové sporty'),
(5, 'Počítače');

INSERT INTO `webpage` (`webPageID`, `URL`, `product`, `categoryID`) VALUES
(1, 'testurl1.cz', NULL, 1),
(2, 'testurl2.cz', NULL, 1),
(3, 'testurl2.cz', NULL, 2),
(4, 'testurl3.cz', NULL, 3),
(5, 'testurl4.cz', NULL, 4),
(6, 'testurl5.cz', NULL, 5),
(7, 'testurl6.cz', NULL, 5),
(8, 'testurl7.cz', NULL, 2);

INSERT INTO `ad` (`adID`, `targetURL`, `title`, `longTitle`, `description`, `companyName`, `nOfViews`, `adGroupID`, `imageID`) VALUES
(1, 'testurl1.cz', 'Titulek1', 'Dlouhý Titulek1', 'A tady je popis1', 'Jewa', NULL, 1, NULL),
(2, 'testurl5.cz', 'Titulek2', 'Dlouhý Titulek2', 'A tady je popis2', 'Jewa1', NULL, 2, NULL),
(3, 'testurl5.cz', 'Titulek3', 'Dlouhý Titulek3', 'A tady je popis3', 'Jewa2', NULL, 2, NULL),
(4, 'testurl7.cz', 'Titulek4', 'Dlouhý Titulek4', 'A tady je popis4', 'Avantgarde', NULL, 3, NULL),
(5, 'testurl7.cz', 'Titulek5', 'Dlouhý Titulek5', 'A tady je popis5', 'Avantgarde1', NULL, 3, NULL),
(6, 'testurl7.cz', 'Titulek6', 'Dlouhý Titulek6', 'A tady je popis6', 'Avantgarde2', NULL, 3, NULL),
(7, 'testurl4.cz', 'Titulek6', 'Dlouhý Titulek6', 'A tady je popis6', 'Avantgarde2', NULL, 4, NULL);


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
(10, NULL, NULL);

INSERT INTO `interest` (`interestID`, `interestName`, `description`) VALUES
(1, 'Elektronika', NULL),
(2, 'Dům a zahrada', NULL),
(3, 'Sport', NULL);

INSERT INTO `Ininterest` (`ininterestID`, `interestID`, `categoryID`) VALUES
(1, 1, 1),
(2, 1, 5),
(3, 2, 3),
(4, 3, 4),
(5, 3, 2);

INSERT INTO `audience` (`audienceID`, `name`, `InterestID`, `categoryID`) VALUES
(1, 'Zájem o elektroniku', 1, NULL),
(2, 'Telefony', NULL, 1),
(3, 'Cyklistika', NULL, 2),
(4, 'Hobby', NULL, 3),
(5, 'Míčové sporty', NULL, 4),
(6, 'Počítače', NULL, 1),
(7, 'Zájem o elektroniku a míčové sporty', 1, 4);

Insert INTO `assignedexcluded` (`aeIDOF`, `audienceID`, `adGroupID`, `action`) VALUES
(1, 2, 1, 1),
(2, 1, 1, 0),
(3, 3, 1, 0),
(4, 4, 1, 0),
(5, 5, 1, 0),
(6, 6, 1, 0),
(7, 7, 1, 0),

(8, 1, 2, 1),
(9, 2, 2, 1),
(10, 3, 2, 0),
(11, 4, 2, 0),
(12, 5, 2, 0),
(13, 6, 2, 0),
(14, 7, 2, 1),

(15, 1, 3, 0),
(16, 2, 3, 0),
(17, 3, 3, 0),
(18, 4, 3, 0),
(19, 5, 3, 1),
(20, 6, 3, 0),
(21, 7, 3, 1),
         
(22, 1, 4, 1),
(23, 2, 4, 1),
(24, 3, 4, 1),
(25, 4, 4, 1),
(26, 5, 4, 1),
(27, 6, 4, 1),
(28, 7, 4, 1);

Insert INTO `AdView` (`viewIDOF`, `adID`, `visitorID`, `viewed`) VALUES
(1, 1, 1, '2019-05-29 00:00:00'),
(2, 1, 1, '2019-05-29 00:00:00'),
(3, 1, 2, '2019-05-29 00:00:00'),
(4, 1, 3, '2019-05-29 00:00:00'),
(5, 2, 4, '2019-05-29 00:00:00'),
(6, 2, 5, '2019-05-29 00:00:00'),
(7, 3, 6, '2019-05-29 00:00:00'),
(8, 3, 7, '2019-05-29 00:00:00'),
(9, 4, 8, '2019-05-29 00:00:00'),
(10, 4, 8, '2019-05-29 00:00:00'),
(11, 5, 10, '2019-05-29 00:00:00'),
(12, 5, 10, '2019-05-29 00:00:00'),
(13, 5, 8, '2019-05-29 00:00:00'),
(14, 5, 1, '2019-05-29 00:00:00'),
(15, 5, 4, '2019-05-29 00:00:00'),
(16, 7, 4, '2019-05-29 00:00:00');



Insert INTO `AdClick` (`clickIDOF`, `adID`, `visitorID`, `clicked`) VALUES

Insert INTO `inAudience` (`inAIDOF`, `audienceID`, `visitorID`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 6, 1),
(4, 7, 1),
(5, 5, 1),
(6, 1, 2),
(7, 2, 2),
(8, 6, 2),
(9, 7, 2),

(10, 3, 3),
(11, 3, 4),
(12, 4, 3),
(13, 4, 5),
(14, 4, 6),

(15, 5, 7),
(16, 7, 7),
(17, 5, 8),
(18, 7, 8),

(19, 1, 9),
(21, 2, 9),
(22, 6, 9),
(23, 7, 9),

(24, 3, 10),
(25, 3, 9),
(26, 4, 10),
(27, 4, 9),
(28, 5, 10),
(29, 7, 10),
(30, 3, 1);






COMMIT;


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
     