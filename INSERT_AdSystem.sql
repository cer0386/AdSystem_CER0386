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

Insert INTO `AdView` (`viewIDOF`, `adID`, `visitorID`, `viewed`) VALUES
(1, 1, 1, '2019-05-29 00:00:00'),
(2, 1, 2, '2019-05-29 00:00:00'),
(3, 1, , '2019-05-29 00:00:00'),
(4, 1, , '2019-05-29 00:00:00'),
(5, 1, , '2019-05-29 00:00:00'),
(6, 1, , '2019-05-29 00:00:00'),


Insert INTO `AdClick` (`clickIDOF`, `adID`, `visitorID`, `clicked`) VALUES

Insert INTO `inAudience` (`inAIDOF`, `audienceID`, `visitorID`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 2, 1),
(7, 2, 2),
(8, 2, 6),
(9, 3, 7),
(10, 4, 8),
(11, 4, 9),
(12, 4, 10),
(13, 5, 10),
(14, 5, 1),
(15, 5, 11),
(16, 5, 12),
(17, 7, 1),
(18, 7, 2),
(19, 7, 3),
(20, 7, 4),
(21, 7, 5),
(22, 1, 6),
(23, 7, 6),
(24, 7, 11),
(25, 7, 12);


COMMIT;


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
     