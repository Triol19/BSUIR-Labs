----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date:    15:57:14 09/20/2015 
-- Design Name: 
-- Module Name:    mux2 - Behavioral 
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

entity mux5 is
	Port (  i : in  STD_LOGIC_VECTOR(7 downto 0);
           c : in  STD_LOGIC_VECTOR(2 downto 0);
           output : out  STD_LOGIC);
end mux5;


architecture Behavioral of mux5 is
-- without 'process' because of not supported construnction (supported in VHDL 1076-2008)
begin
	output <=  i(0) when (c="000") else
			i(1) when (c="001") else
			i(2) when (c="010") else
			i(3) when (c="011") else
			i(4) when (c="100") else
			i(5) when (c="101") else
			i(6) when (c="110") else
			i(7) when (c="111"); 
end Behavioral;