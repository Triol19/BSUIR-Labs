----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    17:12:32 09/11/2015 
-- Design Name: 
-- Module Name:    mux - Behavioral 
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

entity mux is
    Port ( i : in  STD_LOGIC_VECTOR(7 downto 0);
           c : in  STD_LOGIC_VECTOR(2 downto 0);
           output : out  STD_LOGIC);
end mux;

architecture Behavioral of mux is

begin
	output <= ((not c(0)) and (not c(1)) and (not c(2)) and i(0)) or
					(c(0) and (not c(1)) and (not c(2)) and i(1)) or
					((not c(0)) and c(1) and (not c(2)) and i(2)) or
					(c(0) and c(1) and (not c(2)) and i(3)) or
					((not c(0)) and (not c(1)) and c(2) and i(4)) or
					(c(0) and (not c(1)) and c(2) and i(5)) or
					((not c(0)) and c(1) and c(2) and i(6)) or
					(c(0) and c(1) and c(2) and i(7));
end Behavioral;