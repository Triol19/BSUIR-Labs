----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    19:04:46 10/05/2014 
-- Design Name: 
-- Module Name:    FrequencyDivider - Behavioral 
-- Project Name: 
-- Target Devices: 
-- Tool versions: 
-- Description: 
--
-- Dependencies: 
--
-- Revision: 
-- Revision 0.01 - File Created
-- Additional Comments: 
--
----------------------------------------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx primitives in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity FrequencyDivider is
    Port ( CLOCK_IN : in  STD_LOGIC;
           CLOCK_OUT : out  STD_LOGIC);
end FrequencyDivider;

architecture Behavioral of FrequencyDivider is
	constant period : integer := 200000000;
	constant halfPeriod : integer := period / 2;
	signal CLOCK_TMP : std_logic := '0';
begin
	process(CLOCK_IN)	
		variable i : integer := 0; --halfPeriod * (-1);		
		begin
		
			if(CLOCK_IN'event and CLOCK_IN = '1') then
				
				i := i + 1;
				
				if (i = halfPeriod) then 
					
					CLOCK_TMP <= not CLOCK_TMP;
					i := 0;
					
				end if;
				
			end if;
			
	end process;
	
	CLOCK_OUT <= CLOCK_TMP;
	
end Behavioral;

