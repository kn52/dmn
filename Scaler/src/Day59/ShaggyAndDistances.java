package Day59;

import java.util.*;

public class ShaggyAndDistances {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(int[] A) {

		HashMap<Integer, Integer> hm = new HashMap<>();
		int ans = Integer.MAX_VALUE;
		for (int i = 0; i < A.length; i++) {
			if (hm.containsKey(A[i]))
				ans = Math.min(ans, Math.abs(i - hm.get(A[i])));
			else
				hm.put(A[i], i);
		}
		if (ans != Integer.MAX_VALUE)
			return ans;
		else
			return -1;
	}
}
