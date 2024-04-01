package Day0;

import java.util.*;

import Day66.contest;

public class HelloWorld {
	static int[] ans;

	public static void main(String[] args) {
		System.out.println("Hello world");
//		ArrayList<Integer> a = new ArrayList<Integer>(Arrays.asList(16,6, 18, 17,13,6,18,16,6,15,15,18,16,13,16,16,6,18,15,15 )); 
//		subUnsort(a);
//		
//		
//		int [] k = new int[] {16,3,3,6,7,8,17,13,7};
//		int B = 2;
//		solveShipmentInDays(k, B);

		// String A = "absad";
		// String C = "safs";

		// solvew(A, C);
		int[] A = { 13, 4, 10, 17, 6, 16 };
		int n = A.length;
		for (int i = 0; i < n; i++) {
			Arrays.sort(A);
			int min = A[0];
			int max = A[n - 1];
			int avg = (min + max) / 2;

			A[0] += avg;
			A[n - 1] -= avg;
			ans = A;
			System.out.print("");
		}

	}

	public int[] solve(int[] A) {
		int n = A.length;
		ans = new int[n];
		calc(A, n);
		return ans;
	}

	public void calc(int[] A, int n) {
		int[] temp = A;
		for (int i = 0; i < n; i++) {
			Arrays.sort(temp);
			int min = temp[0];
			int max = temp[n - 1];
			int avg = (min + max) / 2;

			temp[0] += avg;
			temp[n - 1] -= avg;
		}
	}

	// 3
	public static int solvew(String A, String B) {
		String a = A;
		String b = B;

		if (a.length() < b.length()) {
			return 0;
		}
		HashMap<String, Integer> map1 = new HashMap<>();
		HashMap<String, Integer> map2 = new HashMap<>();
		int ans = 1;

		for (int i = 0; i < a.length(); i++) {
			String ch = "" + a.charAt(i);
			if (map1.containsKey(ch)) {
				int count = map1.get(ch);
				count += 1;
				map1.put(ch, count);
			} else {
				map2.put(ch, 0);
				map1.put(ch, 1);
			}
		}
		for (int i = 0; i < b.length(); i++) {
			String ch = "" + b.charAt(i);

			if (map1.containsKey(ch)) {
				int mapT = map2.get(ch);
				int mapO = map1.get(ch);

				if (mapT < mapO) {
					int count = mapT + 1;
					map2.put(ch, count);
				} else if (mapT == mapO) {
					return 0;
				}
			} else {
				return 0;
			}
		}
		return ans;
	}

	// 2
	public static long solveShipmentInDays(int[] A, int B) {
		int[] weights = A;
		int d = B;
		int max = Integer.MIN_VALUE;
		int sum = 0;

		for (int i = 0; i < weights.length; i++) {
			if (weights[i] > max) {
				max = weights[i];
			}
			sum += weights[i];
		}

		int low = max;
		int high = sum;
		int ans = -1;

		while (low <= high) {
			int mid = (low + high) / 2;
			int days = finddays(weights, mid);
			if (days <= d) {
				ans = mid;
				high = mid - 1;
			} else {
				low = mid + 1;
			}
		}
		return ans;
	}

	public static int finddays(int[] weights, int cp) {
		int days = 1;
		int load = 0;
		for (int i = 0; i < weights.length; i++) {
			if ((load + weights[i]) < cp) {
				load += weights[i];
			} else {
				days += 1;
				load = weights[i];

			}
		}
		return days;
	}

	// 1
	public static ArrayList<Integer> subUnsort(ArrayList<Integer> A) {
		if (A.size() == 0 || A.size() == 1) {
			ArrayList<Integer> ans = new ArrayList<Integer>();
			ans.add(-1);
			return ans;
		}

		ArrayList<Integer> temp = new ArrayList<Integer>(A);
		ArrayList<Integer> ans = new ArrayList<Integer>();

		Collections.sort(temp);
		int s = 0, e = 0;

		for (int i = 0; i < A.size(); i++) {
			if (A.get(i) != temp.get(i)) {
				s = i;
				break;
			}
		}
		for (int i = A.size() - 1; i >= 0; i--) {
			if (A.get(i) != temp.get(i)) {
				e = i;
				break;
			}
		}

		if (s > 0 && e > 0) {
			for (int i = s; i <= e; i++) {
				ans.add(i);
			}
		} else {
			ans.add(-1);
		}

		return ans;
	}
}
