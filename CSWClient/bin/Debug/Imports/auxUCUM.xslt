<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:esri="http://www.esri.com/metadata/" xmlns:res="http://www.esri.com/metadata/res/">

<!-- An XSLT template for displaying metadata in ArcGIS. These XSLT templates display the official unit of measure name in conjunction with the unit of measure code.

     Copyright (c) 2009-2010, Environmental Systems Research Institute, Inc. All rights reserved.
	
     Revision History: Created 6/15/2009 avienneau
-->

	<xsl:output method="xml" indent="yes"/>
	<xsl:template name="ucum_units">
		<xsl:param name="unit"/>
		<xsl:choose>
			<xsl:when test="($unit = 'Ym')"><xsl:value-of select="$unit"/> (Yotta)</xsl:when>
			<xsl:when test="($unit = 'Zm')"><xsl:value-of select="$unit"/> (Zetta)</xsl:when>
			<xsl:when test="($unit = 'Em')"><xsl:value-of select="$unit"/> (dExa>)</xsl:when>
			<xsl:when test="($unit = 'Pm')"><xsl:value-of select="$unit"/> (Peta)</xsl:when>
			<xsl:when test="($unit = 'Tm')"><xsl:value-of select="$unit"/> (Tera)</xsl:when>
			<xsl:when test="($unit = 'Gm')"><xsl:value-of select="$unit"/> (Giga)</xsl:when>
			<xsl:when test="($unit = 'Mm')"><xsl:value-of select="$unit"/> (Mega)</xsl:when>
			<xsl:when test="($unit = 'km')"><xsl:value-of select="$unit"/> (Kilo)</xsl:when>
			<xsl:when test="($unit = 'hm')"><xsl:value-of select="$unit"/> (Hecto)</xsl:when>
			<xsl:when test="($unit = 'dam')"><xsl:value-of select="$unit"/> (Deka)</xsl:when>
			<xsl:when test="($unit = 'dm')"><xsl:value-of select="$unit"/> (Deci)</xsl:when>
			<xsl:when test="($unit = 'cm')"><xsl:value-of select="$unit"/> (Centi)</xsl:when>
			<xsl:when test="($unit = 'mm')"><xsl:value-of select="$unit"/> (Milli)</xsl:when>
			<xsl:when test="($unit = 'um')"><xsl:value-of select="$unit"/> (Micro)</xsl:when>
			<xsl:when test="($unit = 'nn')"><xsl:value-of select="$unit"/> (Nano)</xsl:when>
			<xsl:when test="($unit = 'pm')"><xsl:value-of select="$unit"/> (Pico)</xsl:when>
			<xsl:when test="($unit = 'fm')"><xsl:value-of select="$unit"/> (Femto)</xsl:when>
			<xsl:when test="($unit = 'am')"><xsl:value-of select="$unit"/> (Atto)</xsl:when>
			<xsl:when test="($unit = 'zm')"><xsl:value-of select="$unit"/> (Zepto)</xsl:when>
			<xsl:when test="($unit = 'ym')"><xsl:value-of select="$unit"/> (Yocto)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'm')"><xsl:value-of select="$unit"/> (Meter)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 's')"><xsl:value-of select="$unit"/> (Second)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'g')"><xsl:value-of select="$unit"/> (Gram)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'rad')"><xsl:value-of select="$unit"/> (Radian)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'k')"><xsl:value-of select="$unit"/> (Kelvin)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'c')"><xsl:value-of select="$unit"/> (Coulomb)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cd')"><xsl:value-of select="$unit"/> (Candela)</xsl:when>
			<xsl:when test="($unit = '10*')"><xsl:value-of select="$unit"/> (TenArbPowsStar)</xsl:when>
			<xsl:when test="($unit = '10^')"><xsl:value-of select="$unit"/> (TenArbPowsCarat)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pi]')"><xsl:value-of select="$unit"/> (Pi)</xsl:when>
			<xsl:when test="($unit = '%')"><xsl:value-of select="$unit"/> (Percent)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ppth]')"><xsl:value-of select="$unit"/> (PPTh)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ppm]')"><xsl:value-of select="$unit"/> (PPM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ppb]')"><xsl:value-of select="$unit"/> (PPB)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pptr]')"><xsl:value-of select="$unit"/> (PPTr)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mol')"><xsl:value-of select="$unit"/> (Mole)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'sr')"><xsl:value-of select="$unit"/> (Steradian)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'hz')"><xsl:value-of select="$unit"/> (Hertz)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'n')"><xsl:value-of select="$unit"/> (Newton)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'pa') or (esri:strtolower($unit) = 'PAL')"><xsl:value-of select="$unit"/> (Pascal)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'j')"><xsl:value-of select="$unit"/> (Joule)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'w')"><xsl:value-of select="$unit"/> (Watt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'a')"><xsl:value-of select="$unit"/> (Amp)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'v')"><xsl:value-of select="$unit"/> (Volt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'f')"><xsl:value-of select="$unit"/> (Farad)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ohm')"><xsl:value-of select="$unit"/> Ohm)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 's') or (esri:strtolower($unit) = 'sie')"><xsl:value-of select="$unit"/> (Siemens)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'wb')"><xsl:value-of select="$unit"/> (Weber)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cel')"><xsl:value-of select="$unit"/> (DegCelsius)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 't')"><xsl:value-of select="$unit"/> (Tesla)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'h')"><xsl:value-of select="$unit"/> (Henry)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'lm')"><xsl:value-of select="$unit"/> (Lumen)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'lx')"><xsl:value-of select="$unit"/> (Lux)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bq')"><xsl:value-of select="$unit"/> (Becquerel)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gy')"><xsl:value-of select="$unit"/> (Gray)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'sv')"><xsl:value-of select="$unit"/> (Sievert)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gon')"><xsl:value-of select="$unit"/> (GonGrade)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'deg')"><xsl:value-of select="$unit"/> (Degree)</xsl:when>
			<xsl:when test='($unit = "&apos;")'><xsl:value-of select="$unit"/> (Minute)</xsl:when>
			<xsl:when test="($unit = '&quot;')"><xsl:value-of select="$unit"/> (Second_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'l')"><xsl:value-of select="$unit"/> (Liter)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ar')"><xsl:value-of select="$unit"/> (Are)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'min')"><xsl:value-of select="$unit"/> (Minute_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'h')"><xsl:value-of select="$unit"/> (Hour)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'd')"><xsl:value-of select="$unit"/> (Day)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'a_t') or (esri:strtolower($unit) = 'ann_t')"><xsl:value-of select="$unit"/> (TropicalYear)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'a_j') or (esri:strtolower($unit) = 'ann_j')"><xsl:value-of select="$unit"/> (MeanJulianYear)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'a_g') or (esri:strtolower($unit) = 'ann_g')"><xsl:value-of select="$unit"/> (MeanGregorianYear)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'a') or (esri:strtolower($unit) = 'ann')"><xsl:value-of select="$unit"/> (Year)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'wk')"><xsl:value-of select="$unit"/> (Week)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mo_s')"><xsl:value-of select="$unit"/> (SynodalMonth)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mo_j')"><xsl:value-of select="$unit"/> (MeanJulianMonth)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mo_g')"><xsl:value-of select="$unit"/> (MeanGregorianMonth)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mo')"><xsl:value-of select="$unit"/> (Month)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 't') or (esri:strtolower($unit) = 'tne')"><xsl:value-of select="$unit"/> (Tonne)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bar')"><xsl:value-of select="$unit"/> (Bar)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'u') or (esri:strtolower($unit) = 'amu')"><xsl:value-of select="$unit"/> (AMU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ev')"><xsl:value-of select="$unit"/> (EV)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'au') or (esri:strtolower($unit) = 'asu')"><xsl:value-of select="$unit"/> (AU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'pc') or (esri:strtolower($unit) = 'prs')"><xsl:value-of select="$unit"/> (Parsec)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[c]')"><xsl:value-of select="$unit"/> (VelocityOfLight)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[h]')"><xsl:value-of select="$unit"/> (PlanckConstant)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[k]')"><xsl:value-of select="$unit"/> (BoltzmannConstant)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[eps_0]')"><xsl:value-of select="$unit"/> (PermittivityOfVacuum)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mu_0]')"><xsl:value-of select="$unit"/> (PermeabilityOfVacuum)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[e]')"><xsl:value-of select="$unit"/> (ElementaryCharge)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[m_e]')"><xsl:value-of select="$unit"/> (ElectronMass)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[m_p]')"><xsl:value-of select="$unit"/> (ProtonMass)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[g]') or (esri:strtolower($unit) = '[gc]')"><xsl:value-of select="$unit"/> (NewtonGravConstant)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[g]')"><xsl:value-of select="$unit"/> (StdFreefallAccel)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'atm')"><xsl:value-of select="$unit"/> (StdAtmo)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ly]')"><xsl:value-of select="$unit"/> (Lightyear)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gf')"><xsl:value-of select="$unit"/> (GramForce)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lbf_av]')"><xsl:value-of select="$unit"/> (PoundForce)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ky')"><xsl:value-of select="$unit"/> (Kayser)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gal') or (esri:strtolower($unit) = 'gl')"><xsl:value-of select="$unit"/> (Gal)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'dyn')"><xsl:value-of select="$unit"/> (Dyne)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'erg')"><xsl:value-of select="$unit"/> (Erg)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'p')"><xsl:value-of select="$unit"/> (Poise)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bi')"><xsl:value-of select="$unit"/> (Biot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'st')"><xsl:value-of select="$unit"/> (Stokes)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mx')"><xsl:value-of select="$unit"/> (Maxwell)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'g') or (esri:strtolower($unit) = 'gs')"><xsl:value-of select="$unit"/> (Gauss)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'oe')"><xsl:value-of select="$unit"/> (Oersted)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gb')"><xsl:value-of select="$unit"/> (Gilbert)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'sb')"><xsl:value-of select="$unit"/> (Stilb)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'lmb')"><xsl:value-of select="$unit"/> (Lambert)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ph') or (esri:strtolower($unit) = 'pht')"><xsl:value-of select="$unit"/> (Phot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ci')"><xsl:value-of select="$unit"/> (Curie)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'r') or (esri:strtolower($unit) = 'roe')"><xsl:value-of select="$unit"/> (Roentgen)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'rad') or (esri:strtolower($unit) = '[rad]')"><xsl:value-of select="$unit"/> (RadiationAbsorbedDose)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'rem') or (esri:strtolower($unit) = '[rem]')"><xsl:value-of select="$unit"/> (RadiationEquivalentMan)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[in_i]')"><xsl:value-of select="$unit"/> (Inch)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ft_i]')"><xsl:value-of select="$unit"/> (Foot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[yd_i]')"><xsl:value-of select="$unit"/> (Yard)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mi_i]')"><xsl:value-of select="$unit"/> (StatuteMile)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fth_i]')"><xsl:value-of select="$unit"/> (Fathom)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[nmi_i]')"><xsl:value-of select="$unit"/> (NauticalMile)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[kn_i]')"><xsl:value-of select="$unit"/> (Knot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[sin_i]')"><xsl:value-of select="$unit"/> (SquareInch)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[sft_i]')"><xsl:value-of select="$unit"/> (SquareFoot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[syd_i]')"><xsl:value-of select="$unit"/> (SquareYard)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cin_i]')"><xsl:value-of select="$unit"/> (CubicInch)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cft_i]')"><xsl:value-of select="$unit"/> (CubicFoot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cyd_i]')"><xsl:value-of select="$unit"/> (CubicYard)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[bf_i]')"><xsl:value-of select="$unit"/> (BoardFoot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cr_i]')"><xsl:value-of select="$unit"/> (Cord)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mil_i]')"><xsl:value-of select="$unit"/> (Mil)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cml_i]')"><xsl:value-of select="$unit"/> (CircularMil)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[hd_i]')"><xsl:value-of select="$unit"/> (Hand)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ft_us]')"><xsl:value-of select="$unit"/> (Foot_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[yd_us]')"><xsl:value-of select="$unit"/> (Yard_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[in_us]')"><xsl:value-of select="$unit"/> (Inch_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[rd_us]')"><xsl:value-of select="$unit"/> (Rod)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ch_us]')"><xsl:value-of select="$unit"/> (GunterSurveyorChain)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lk_us]')"><xsl:value-of select="$unit"/> (GunterChainLink)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[rch_us]')"><xsl:value-of select="$unit"/> (RamdenEngineerChain)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[rlk_us]')"><xsl:value-of select="$unit"/> (RamdenChainLink)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fth_us]')"><xsl:value-of select="$unit"/> (Fathom_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fur_us]')"><xsl:value-of select="$unit"/> (Furlong)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mi_us]')"><xsl:value-of select="$unit"/> Mile)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[acr_us]')"><xsl:value-of select="$unit"/> (Acre)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[srd_us]')"><xsl:value-of select="$unit"/> (SquareRod)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[smi_us]')"><xsl:value-of select="$unit"/> (SquareMile)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[sct]')"><xsl:value-of select="$unit"/> (Section)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[twp]')"><xsl:value-of select="$unit"/> (Township)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mil_us]')"><xsl:value-of select="$unit"/> (Mil_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[in_br]')"><xsl:value-of select="$unit"/> (Inch_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ft_br]')"><xsl:value-of select="$unit"/> (Foot_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[rd_br]')"><xsl:value-of select="$unit"/> (Rod_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ch_br]')"><xsl:value-of select="$unit"/> (GunterChain)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lk_br]')"><xsl:value-of select="$unit"/> (GunterChainLink_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fth_br]')"><xsl:value-of select="$unit"/> (Fathom_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pc_br]')"><xsl:value-of select="$unit"/> (Pace)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[yd_br]')"><xsl:value-of select="$unit"/> (Yard_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mi_br]')"><xsl:value-of select="$unit"/> (Mile_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[nmi_br]')"><xsl:value-of select="$unit"/> (NauticalMile_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[kn_br]')"><xsl:value-of select="$unit"/> (Knot_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[acr_br]')"><xsl:value-of select="$unit"/> (Acre_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gal_us]')"><xsl:value-of select="$unit"/> (QueenAnneWineGallon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[bbl_us]')"><xsl:value-of select="$unit"/> (Barrel)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[qt_us]')"><xsl:value-of select="$unit"/> (Quart)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pt_us]')"><xsl:value-of select="$unit"/> (Pint)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gil_us]')"><xsl:value-of select="$unit"/> (Gill)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[foz_us]')"><xsl:value-of select="$unit"/> (FluidOunce)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fdr_us]')"><xsl:value-of select="$unit"/> (FluidDram)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[min_us]')"><xsl:value-of select="$unit"/> (Minim)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[crd_us]')"><xsl:value-of select="$unit"/> (Cord_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[bu_us]')"><xsl:value-of select="$unit"/> (Bushel)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gal_wi]')"><xsl:value-of select="$unit"/> (HistWinchesterGallon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pk_us]')"><xsl:value-of select="$unit"/> (Peck)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[dqt_us]')"><xsl:value-of select="$unit"/> (DryQuart)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[dpt_us]')"><xsl:value-of select="$unit"/> (DryPint)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[tbs_us]')"><xsl:value-of select="$unit"/> (Tablespoon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[tsp_us]')"><xsl:value-of select="$unit"/> (Teaspoon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cup_us]')"><xsl:value-of select="$unit"/> (Cup)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gal_br]')"><xsl:value-of select="$unit"/> (Gallon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pk_br]')"><xsl:value-of select="$unit"/> (Peck_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[bu_br]')"><xsl:value-of select="$unit"/> (Bushel_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[qt_br]')"><xsl:value-of select="$unit"/> (Quart_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pt_br]')"><xsl:value-of select="$unit"/> (Pint_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gil_br]')"><xsl:value-of select="$unit"/> (Gill_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[foz_br]')"><xsl:value-of select="$unit"/> (FluidOunce_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[fdr_br]')"><xsl:value-of select="$unit"/> (FluidDram_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[min_br]')"><xsl:value-of select="$unit"/> (Minim_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[gr]')"><xsl:value-of select="$unit"/> (Grain)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lb_av]')"><xsl:value-of select="$unit"/> (Pound)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[oz_av]')"><xsl:value-of select="$unit"/> (Ounce)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[dr_av]')"><xsl:value-of select="$unit"/> (Dram)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[scwt_av]')"><xsl:value-of select="$unit"/> (ShortUSHundredweight)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lcwt_av]')"><xsl:value-of select="$unit"/> (LongBritishHundredweight)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ston_av]')"><xsl:value-of select="$unit"/> (ShortUSTon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lton_av]')"><xsl:value-of select="$unit"/> (LongBritishTon)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[stone_av]') "><xsl:value-of select="$unit"/> (BritishStone)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pwt_tr]')"><xsl:value-of select="$unit"/> (Pennyweight)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[oz_tr]')"><xsl:value-of select="$unit"/> (Ounce_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lb_tr]')"><xsl:value-of select="$unit"/> (Pound_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[sc_ap]')"><xsl:value-of select="$unit"/> (Scruple)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[dr_ap]')"><xsl:value-of select="$unit"/> (DramDrachm)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[oz_ap]')"><xsl:value-of select="$unit"/> (Ounce_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lb_ap]')"><xsl:value-of select="$unit"/> (Pound_auxUCUM_0)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lne]')"><xsl:value-of select="$unit"/> (Line)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pnt]')"><xsl:value-of select="$unit"/> (Point_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pca]')"><xsl:value-of select="$unit"/> (Pica)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pnt_pr]')"><xsl:value-of select="$unit"/> (PrinterPoint)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pca_pr]')"><xsl:value-of select="$unit"/> (PrinterPica/>))</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pied]')"><xsl:value-of select="$unit"/> (PiedFrenchFoot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pouce]')"><xsl:value-of select="$unit"/> (PouceFrenchInch)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ligne]')"><xsl:value-of select="$unit"/> (LigneFrenchLine)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[didot]')"><xsl:value-of select="$unit"/> (DidotPoint)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cicero]')"><xsl:value-of select="$unit"/> (CiceroDidotPica)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[degf]')"><xsl:value-of select="$unit"/> (DegreeFahrenheit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal_[15]')"><xsl:value-of select="$unit"/> (CalorieAt15C)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal_[20]')"><xsl:value-of select="$unit"/> (CalorieAt20C)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal_m')"><xsl:value-of select="$unit"/> (MeanCalorie)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal_it')"><xsl:value-of select="$unit"/> (IntlTableCalorie)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal_th')"><xsl:value-of select="$unit"/> (ThermochemCalorie)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'cal')"><xsl:value-of select="$unit"/> (Calorie)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cal]')"><xsl:value-of select="$unit"/> (NutritionLabelCalories)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_39]')"><xsl:value-of select="$unit"/> (BTUAt39F)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_59]')"><xsl:value-of select="$unit"/> (BTUAt59F)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_60]')"><xsl:value-of select="$unit"/> (BTUAt60F)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_m]')"><xsl:value-of select="$unit"/> (MeanBTU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_IT]')"><xsl:value-of select="$unit"/> (IntlTableBTU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu_th]')"><xsl:value-of select="$unit"/> (ThermochemBTU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[btu]')"><xsl:value-of select="$unit"/> (BTU)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[hp]')"><xsl:value-of select="$unit"/> (Horsepower)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'm[h2o]')"><xsl:value-of select="$unit"/> (MeterOfWaterColumn)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'm[hg]')"><xsl:value-of select="$unit"/> (MeterOfMercuryColumn)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[in_i&apos;h2o]")'><xsl:value-of select="$unit"/> (InchOfWaterColumn)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[in_i&apos;hg]")'><xsl:value-of select="$unit"/> (InchOfMercuryColumn)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pru]')"><xsl:value-of select="$unit"/> (PeripheralVascularResistanceUnit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[diop]')"><xsl:value-of select="$unit"/> (Diopter)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[p&apos;diop]")'><xsl:value-of select="$unit"/> (PrismDiopter)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '%[slope]')"><xsl:value-of select="$unit"/> (PercentOfSlope)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[mesh_i]')"><xsl:value-of select="$unit"/> (Mesh)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ch]')"><xsl:value-of select="$unit"/> (CharriereFrench)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[drp]')"><xsl:value-of select="$unit"/> (Drop)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[hnsf&apos;u]")'><xsl:value-of select="$unit"/> (HounsfieldUnit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[met]')"><xsl:value-of select="$unit"/> (MetabolicEquivalent)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[hp_x]')"><xsl:value-of select="$unit"/> (HomeopathicPotencyOfDecimalSeries)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[hp_c]')"><xsl:value-of select="$unit"/> (HomeopathicPotencyOfCentesimalSeries)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'eq')"><xsl:value-of select="$unit"/> (Equivalents)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'osm')"><xsl:value-of select="$unit"/> (Osmole)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ph]')"><xsl:value-of select="$unit"/> (Ph)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'g%')"><xsl:value-of select="$unit"/> (GramPercent)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[s]')"><xsl:value-of select="$unit"/> (SvedbergUnit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[hpf]')"><xsl:value-of select="$unit"/> (HighPowerField)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[lpf]')"><xsl:value-of select="$unit"/> (LowPowerField)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'kat')"><xsl:value-of select="$unit"/> (Katal)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'u')"><xsl:value-of select="$unit"/> (Unit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[iu]')"><xsl:value-of select="$unit"/> (IntlUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[arb&apos;u]")'><xsl:value-of select="$unit"/> (ArbitaryUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[usp&apos;u]")'><xsl:value-of select="$unit"/> (UnitedStatesPharmacopeiaUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[gpl&apos;u]")'><xsl:value-of select="$unit"/> (GPLUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[mpl&apos;u]")'><xsl:value-of select="$unit"/> (MPLUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[apl&apos;u]")'><xsl:value-of select="$unit"/> (APLUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[beth&apos;u]")'><xsl:value-of select="$unit"/> (BethesdaUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[todd&apos;u]")'><xsl:value-of select="$unit"/> (ToddUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[dye&apos;u]")'><xsl:value-of select="$unit"/> (DyeUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[smgy&apos;u]")'><xsl:value-of select="$unit"/> (SomogyiUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[bdsk&apos;u]")'><xsl:value-of select="$unit"/> (BodanskyUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[ka&apos;u]")'><xsl:value-of select="$unit"/> (KingArmstrongUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[knk&apos;u]")'><xsl:value-of select="$unit"/> (KunkelUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[mclg&apos;u]")'><xsl:value-of select="$unit"/> (MacLaganUnit)</xsl:when>
			<xsl:when test='(esri:strtolower($unit) = "[tb&apos;u]")'><xsl:value-of select="$unit"/> (TuberculinUnit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ccid_50]')"><xsl:value-of select="$unit"/> (50PctCellCultureInfectiousDose)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[tcid_50]')"><xsl:value-of select="$unit"/> (50PctTissueCultureInfectiousDose)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[pfu]')"><xsl:value-of select="$unit"/> (PlaqueFormingUnits)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[ffu]')"><xsl:value-of select="$unit"/> (ImmunofocusFormingUnits)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[cfu]')"><xsl:value-of select="$unit"/> (ColonyFormingUnits)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'np') or (esri:strtolower($unit) = 'nep')"><xsl:value-of select="$unit"/> (Neper)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b')"><xsl:value-of select="$unit"/> (Bel)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[spl]')"><xsl:value-of select="$unit"/> (BelSoundPressure)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[v]')"><xsl:value-of select="$unit"/> (BelVolt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[mv]')"><xsl:value-of select="$unit"/> (BelMillivolt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[uv]')"><xsl:value-of select="$unit"/> (BelMicrovolt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[w]')"><xsl:value-of select="$unit"/> (BelWatt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b[kw]')"><xsl:value-of select="$unit"/> (BelKilowatt)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'st') or (esri:strtolower($unit) = 'str')"><xsl:value-of select="$unit"/> (Stere)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ao')"><xsl:value-of select="$unit"/> (Angstrom)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'b') or (esri:strtolower($unit) = 'brn')"><xsl:value-of select="$unit"/> (Barn)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'att')"><xsl:value-of select="$unit"/> (TechAtmo)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mho')"><xsl:value-of select="$unit"/> (Mho)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[psi]')"><xsl:value-of select="$unit"/> (PoundPerSqareInch)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'circ')"><xsl:value-of select="$unit"/> (Circle)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'sph')"><xsl:value-of select="$unit"/> (Spere)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[car_m]')"><xsl:value-of select="$unit"/> (MetricCarat)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[car_au]')"><xsl:value-of select="$unit"/> (CaratOfGoldAlloys)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = '[smoot]')"><xsl:value-of select="$unit"/> (Smoot)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bit_s')"><xsl:value-of select="$unit"/> (Bit)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bit')"><xsl:value-of select="$unit"/> (Bit_auxUCUM)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'by')"><xsl:value-of select="$unit"/> (Byte)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'bd')"><xsl:value-of select="$unit"/> (Baud)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ki') or (esri:strtolower($unit) = 'kib')"><xsl:value-of select="$unit"/> (Kibi)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'mi') or (esri:strtolower($unit) = 'mib')"><xsl:value-of select="$unit"/> (Mebi)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'gi') or (esri:strtolower($unit) = 'gib')"><xsl:value-of select="$unit"/> (Gibi)</xsl:when>
			<xsl:when test="(esri:strtolower($unit) = 'ti') or (esri:strtolower($unit) = 'tib')"><xsl:value-of select="$unit"/> (Tebi)</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="."/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>