-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 26, 2019 at 03:55 AM
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

-- --------------------------------------------------------

--
-- Table structure for table `ad`
--

CREATE TABLE `ad` (
  `adID` int(11) NOT NULL,
  `targetURL` varchar(1000) NOT NULL,
  `title` varchar(30) NOT NULL,
  `longTitle` varchar(90) NOT NULL,
  `description` varchar(90) NOT NULL,
  `companyName` varchar(30) NOT NULL,
  `nOfViews` int(11) DEFAULT NULL,
  `adGroupID` int(11) NOT NULL,
  `webPageID` int(11) NOT NULL,
  `imageID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `adcampaign`
--

CREATE TABLE `adcampaign` (
  `campaignID` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `type` varchar(50) NOT NULL,
  `status` tinyint(4) NOT NULL,
  `budget` decimal(8,2) NOT NULL,
  `costPer` decimal(4,2) NOT NULL,
  `start` datetime NOT NULL,
  `ending` datetime DEFAULT NULL,
  `companyID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `adclick`
--

CREATE TABLE `adclick` (
  `clickIDOF` int(11) NOT NULL,
  `adID` int(11) NOT NULL,
  `visitorID` int(11) NOT NULL,
  `clicked` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `adgroup`
--

CREATE TABLE `adgroup` (
  `adGroupID` int(11) NOT NULL,
  `adGroupName` varchar(50) NOT NULL,
  `adGroupStatus` tinyint(4) NOT NULL,
  `adGroupBudget` decimal(8,2) DEFAULT NULL,
  `maxCostPer` decimal(4,2) DEFAULT NULL,
  `requiredViews` int(11) NOT NULL,
  `campaignID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `adview`
--

CREATE TABLE `adview` (
  `viewIDOF` int(11) NOT NULL,
  `adID` int(11) NOT NULL,
  `visitorID` int(11) NOT NULL,
  `viewed` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `assignedexcluded`
--

CREATE TABLE `assignedexcluded` (
  `aeIDOF` int(11) NOT NULL,
  `audienceID` int(11) NOT NULL,
  `adGroupID` int(11) NOT NULL,
  `action` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `audience`
--

CREATE TABLE `audience` (
  `audienceID` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `InterestID` int(11) DEFAULT NULL,
  `categoryID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `categoryID` int(11) NOT NULL,
  `categoryName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `company`
--

CREATE TABLE `company` (
  `companyID` int(11) NOT NULL,
  `companyName` varchar(100) NOT NULL,
  `VIP` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `image`
--

CREATE TABLE `image` (
  `imageID` int(11) NOT NULL,
  `imagePath` varchar(200) NOT NULL,
  `description` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `inaudience`
--

CREATE TABLE `inaudience` (
  `inAIDOF` int(11) NOT NULL,
  `audienceID` int(11) NOT NULL,
  `visitorID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `interest`
--

CREATE TABLE `interest` (
  `interestID` int(11) NOT NULL,
  `interestName` varchar(50) NOT NULL,
  `description` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `visit`
--

CREATE TABLE `visit` (
  `visitIDOF` int(11) NOT NULL,
  `visitorID` int(11) NOT NULL,
  `webPageID` int(11) NOT NULL,
  `visited` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `visitor`
--

CREATE TABLE `visitor` (
  `visitorID` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `location` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `webpage`
--

CREATE TABLE `webpage` (
  `webPageID` int(11) NOT NULL,
  `URL` text NOT NULL,
  `product` varchar(100) DEFAULT NULL,
  `categoryID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ad`
--
ALTER TABLE `ad`
  ADD PRIMARY KEY (`adID`),
  ADD KEY `adGroupID` (`adGroupID`),
  ADD KEY `imageID` (`imageID`),
  ADD KEY `webPageID` (`webPageID`);

--
-- Indexes for table `adcampaign`
--
ALTER TABLE `adcampaign`
  ADD PRIMARY KEY (`campaignID`),
  ADD KEY `companyID` (`companyID`);

--
-- Indexes for table `adclick`
--
ALTER TABLE `adclick`
  ADD PRIMARY KEY (`clickIDOF`),
  ADD KEY `adID` (`adID`),
  ADD KEY `visitorID` (`visitorID`);

--
-- Indexes for table `adgroup`
--
ALTER TABLE `adgroup`
  ADD PRIMARY KEY (`adGroupID`),
  ADD KEY `campaignID` (`campaignID`);

--
-- Indexes for table `adview`
--
ALTER TABLE `adview`
  ADD PRIMARY KEY (`viewIDOF`),
  ADD KEY `adID` (`adID`),
  ADD KEY `visitorID` (`visitorID`);

--
-- Indexes for table `assignedexcluded`
--
ALTER TABLE `assignedexcluded`
  ADD PRIMARY KEY (`aeIDOF`),
  ADD KEY `adGroupID` (`adGroupID`),
  ADD KEY `audienceID` (`audienceID`);

--
-- Indexes for table `audience`
--
ALTER TABLE `audience`
  ADD PRIMARY KEY (`audienceID`),
  ADD KEY `categoryID` (`categoryID`),
  ADD KEY `InterestID` (`InterestID`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`categoryID`);

--
-- Indexes for table `company`
--
ALTER TABLE `company`
  ADD PRIMARY KEY (`companyID`);

--
-- Indexes for table `image`
--
ALTER TABLE `image`
  ADD PRIMARY KEY (`imageID`);

--
-- Indexes for table `inaudience`
--
ALTER TABLE `inaudience`
  ADD PRIMARY KEY (`inAIDOF`),
  ADD KEY `audienceID` (`audienceID`),
  ADD KEY `visitorID` (`visitorID`);

--
-- Indexes for table `interest`
--
ALTER TABLE `interest`
  ADD PRIMARY KEY (`interestID`);

--
-- Indexes for table `visit`
--
ALTER TABLE `visit`
  ADD PRIMARY KEY (`visitIDOF`),
  ADD KEY `visitorID` (`visitorID`),
  ADD KEY `webPageID` (`webPageID`);

--
-- Indexes for table `visitor`
--
ALTER TABLE `visitor`
  ADD PRIMARY KEY (`visitorID`);

--
-- Indexes for table `webpage`
--
ALTER TABLE `webpage`
  ADD PRIMARY KEY (`webPageID`),
  ADD KEY `categoryID` (`categoryID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ad`
--
ALTER TABLE `ad`
  MODIFY `adID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `adcampaign`
--
ALTER TABLE `adcampaign`
  MODIFY `campaignID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `adclick`
--
ALTER TABLE `adclick`
  MODIFY `clickIDOF` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `adgroup`
--
ALTER TABLE `adgroup`
  MODIFY `adGroupID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `adview`
--
ALTER TABLE `adview`
  MODIFY `viewIDOF` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `assignedexcluded`
--
ALTER TABLE `assignedexcluded`
  MODIFY `aeIDOF` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `audience`
--
ALTER TABLE `audience`
  MODIFY `audienceID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `categoryID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `image`
--
ALTER TABLE `image`
  MODIFY `imageID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inaudience`
--
ALTER TABLE `inaudience`
  MODIFY `inAIDOF` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `interest`
--
ALTER TABLE `interest`
  MODIFY `interestID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `visit`
--
ALTER TABLE `visit`
  MODIFY `visitIDOF` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `webpage`
--
ALTER TABLE `webpage`
  MODIFY `webPageID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ad`
--
ALTER TABLE `ad`
  ADD CONSTRAINT `ad_ibfk_1` FOREIGN KEY (`adGroupID`) REFERENCES `adgroup` (`adGroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ad_ibfk_2` FOREIGN KEY (`imageID`) REFERENCES `image` (`imageID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `ad_ibfk_3` FOREIGN KEY (`webPageID`) REFERENCES `webpage` (`webPageID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `adcampaign`
--
ALTER TABLE `adcampaign`
  ADD CONSTRAINT `adcampaign_ibfk_1` FOREIGN KEY (`companyID`) REFERENCES `company` (`companyID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `adclick`
--
ALTER TABLE `adclick`
  ADD CONSTRAINT `adclick_ibfk_1` FOREIGN KEY (`adID`) REFERENCES `ad` (`adID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `adclick_ibfk_2` FOREIGN KEY (`visitorID`) REFERENCES `visitor` (`visitorID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `adgroup`
--
ALTER TABLE `adgroup`
  ADD CONSTRAINT `adgroup_ibfk_1` FOREIGN KEY (`campaignID`) REFERENCES `adcampaign` (`campaignID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `adview`
--
ALTER TABLE `adview`
  ADD CONSTRAINT `adview_ibfk_1` FOREIGN KEY (`adID`) REFERENCES `ad` (`adID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `adview_ibfk_2` FOREIGN KEY (`visitorID`) REFERENCES `visitor` (`visitorID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `assignedexcluded`
--
ALTER TABLE `assignedexcluded`
  ADD CONSTRAINT `assignedexcluded_ibfk_1` FOREIGN KEY (`adGroupID`) REFERENCES `adgroup` (`adGroupID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `assignedexcluded_ibfk_2` FOREIGN KEY (`audienceID`) REFERENCES `audience` (`audienceID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `audience`
--
ALTER TABLE `audience`
  ADD CONSTRAINT `audience_ibfk_1` FOREIGN KEY (`categoryID`) REFERENCES `category` (`categoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `audience_ibfk_2` FOREIGN KEY (`InterestID`) REFERENCES `interest` (`interestID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `inaudience`
--
ALTER TABLE `inaudience`
  ADD CONSTRAINT `inaudience_ibfk_1` FOREIGN KEY (`audienceID`) REFERENCES `audience` (`audienceID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `inaudience_ibfk_2` FOREIGN KEY (`visitorID`) REFERENCES `visitor` (`visitorID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `visit`
--
ALTER TABLE `visit`
  ADD CONSTRAINT `visit_ibfk_1` FOREIGN KEY (`visitorID`) REFERENCES `visitor` (`visitorID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `visit_ibfk_2` FOREIGN KEY (`webPageID`) REFERENCES `webpage` (`webPageID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `webpage`
--
ALTER TABLE `webpage`
  ADD CONSTRAINT `webpage_ibfk_1` FOREIGN KEY (`categoryID`) REFERENCES `category` (`categoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
